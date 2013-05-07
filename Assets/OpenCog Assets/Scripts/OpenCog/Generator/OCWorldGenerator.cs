using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;


[AddComponentMenu("VoxelEngine/WorldGenerator")]
public class OCWorldGenerator : MonoBehaviour {
	
	private OpenCog.Map.OCMap map;
	private OpenCog.Map.OCColumnMap columnMap = new OpenCog.Map.OCColumnMap();
	private OCTerrainGenerator terrainGenerator;
	private OCTreeGenerator[] treeGenerator;
	private bool building = false;
	private bool collidersUpToDate = false;
	
	private int worldGenerationRadius = 1;
	
	public string MapName;
	
	void Awake() {
		map = GetComponent<Map>();
		
		if (MapName != string.Empty)
		{
			Debug.Log ("In WorldGenerator, MapName defined");
			OCFileTerrainGenerator fileTerrainGenerator = new OCFileTerrainGenerator(map, MapName);
			
			fileTerrainGenerator.LoadLevel();
		}
		else
		{
			terrainGenerator = new OCTerrainGenerator(map);
			
			Block[] woodBlocks = map.GetBlockSet().GetBlocks("Wood");
			Block[] leavesBlocks = map.GetBlockSet().GetBlocks("Leaves");
			
			treeGenerator = new OCTreeGenerator[ Math.Max(woodBlocks.Length, leavesBlocks.Length) ];
			for(int i=0; i<treeGenerator.Length; i++) {
				Block wood = woodBlocks[ i%woodBlocks.Length ];
				Block leaves = leavesBlocks[ i%leavesBlocks.Length ];
				treeGenerator[i] = new OCTreeGenerator(map, wood, leaves);
			}	
		}
	}
	
	void Update() {
		if(!building) StartCoroutine( Building() );
	}
	
	private IEnumerator Building() {
		if (MapName == String.Empty)
		{
			building = true;
			Vector3 pos = Camera.mainCamera.transform.position;
			Vector3i current = OCChunk.ToChunkPosition( (int)pos.x, (int)pos.y, (int)pos.z );
			Vector3i? column = columnMap.GetClosestEmptyColumn(current.x, current.z, worldGenerationRadius);
			
			if (column == null)
			{
				// No more columns to create...let's update the colliders
				map.AddColliders ();
				
				collidersUpToDate = true;
			}
			else
			{
				if(column.HasValue) {
					int cx = column.Value.x;
					int cz = column.Value.z;
					columnMap.SetBuilt(cx, cz);
					
					yield return StartCoroutine( GenerateColumn(cx, cz) );
					yield return null;
					OCChunkSunLightComputer.ComputeRays(map, cx, cz);
					OCChunkSunLightComputer.Scatter(map, columnMap, cx, cz);
					terrainGenerator.GeneratePlants(cx, cz);
					
					collidersUpToDate = false;
					
					yield return StartCoroutine( BuildColumn(cx, cz) );
				}
			}
				
				
			
			building = false;	
		}
	}
	
	private IEnumerator GenerateColumn(int cx, int cz) {
		if (MapName == string.Empty)
		{
			yield return StartCoroutine( terrainGenerator.Generate(cx, cz) );
			yield return null;
			
			if(treeGenerator.Length > 0) {
				int x = cx * OCChunk.SIZE_X + OCChunk.SIZE_X/2;
				int z = cz * OCChunk.SIZE_Z + OCChunk.SIZE_Z/2;
				int y = map.GetMaxY(x, z)+1;
				int index = UnityEngine.Random.Range( 0, treeGenerator.Length );
				treeGenerator[index].Generate(x, y, z);
			}
		}
	}
	
	public IEnumerator BuildColumn(int cx, int cz) {
		List3D<OCChunk> chunks = map.GetChunks();
		for(int cy=chunks.GetMinY(); cy<chunks.GetMaxY(); cy++) {
			OCChunk chunk = map.GetChunk( new Vector3i(cx, cy, cz) );
			if(chunk != null) chunk.GetChunkRendererInstance().SetDirty();
			if(chunk != null) yield return null;
		}
	}
	
	
}