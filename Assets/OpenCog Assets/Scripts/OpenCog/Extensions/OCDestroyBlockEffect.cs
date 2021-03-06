
/// Unity3D OpenCog World Embodiment Program
/// Copyright (C) 2013  Novamente            
///
/// This program is free software: you can redistribute it and/or modify
/// it under the terms of the GNU Affero General Public License as
/// published by the Free Software Foundation, either version 3 of the
/// License, or (at your option) any later version.
///
/// This program is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU Affero General Public License for more details.
///
/// You should have received a copy of the GNU Affero General Public License
/// along with this program.  If not, see <http://www.gnu.org/licenses/>.

#region Usings, Namespaces, and Pragmas

using System.Collections;
using OpenCog.Attributes;
using OpenCog.Extensions;
using ImplicitFields = ProtoBuf.ImplicitFields;
using ProtoContract = ProtoBuf.ProtoContractAttribute;
using Serializable = System.SerializableAttribute;
using OpenCog.Map;
using GameObject = UnityEngine.GameObject;
using System.Linq;
using System.Collections.Generic;

//The private field is assigned but its value is never used
#pragma warning disable 0414

#endregion

namespace OpenCog
{

/// <summary>
/// The OpenCog OCDestroyBlockEffect.
/// </summary>
#region Class Attributes

[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
[OCExposePropertyFields]
[Serializable]
    
#endregion
public class OCDestroyBlockEffect : OCMonoBehaviour
{

    //---------------------------------------------------------------------------

    #region Private Member Data

    //---------------------------------------------------------------------------
    

            
    //---------------------------------------------------------------------------

    #endregion

    //---------------------------------------------------------------------------

    #region Accessors and Mutators

    //---------------------------------------------------------------------------
        

            
    //---------------------------------------------------------------------------

    #endregion

    //---------------------------------------------------------------------------

    #region Public Member Functions

    //---------------------------------------------------------------------------

    public void DestroyBlock(Vector3i? point)
		{
			if(point.HasValue)
			{
				OCMap map = (OCMap)GameObject.FindSceneObjectsOfType(typeof(OCMap)).FirstOrDefault();
				map.SetBlockAndRecompute(new OpenCog.Map.OCBlockData(), point.Value);
			}
		}

    //---------------------------------------------------------------------------

    #endregion

    //---------------------------------------------------------------------------

    #region Private Member Functions

    //---------------------------------------------------------------------------
    
    
            
    //---------------------------------------------------------------------------

    #endregion

    //---------------------------------------------------------------------------

    #region Other Members

    //---------------------------------------------------------------------------        

    

    //---------------------------------------------------------------------------

    #endregion

    //---------------------------------------------------------------------------

}// class OCDestroyBlockEffect

}// namespace OpenCog




