﻿#region License
/*

Copyright 2011, Iain Sproat
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are
met:

 * Redistributions of source code must retain the above copyright
notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above
copyright notice, this list of conditions and the following disclaimer
in the documentation and/or other materials provided with the
distribution.
 * The names of the contributors may not be used to endorse or promote products derived from
this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

 */
#endregion

using System;
using System.Collections.Generic;

namespace IfcDotNet.Schema
{
	/// <summary>
	/// This select type identifies all those types of entities which may participate in a Boolean operation to form a CSG solid. 
	/// </summary>
	public interface IfcBooleanOperand{
	    /// <summary>
	    /// Dimension of the IfcBooleanOperand
	    /// </summary>
		IfcDimensionCount1 Dim{ get; }
	}
	
	/// <summary>
	/// 
	/// </summary>
	public interface IfcAxis2Placement{
	    /// <summary>
	    /// 
	    /// </summary>
	    IList<IfcDirection> P{ get; }
	}
	
	/// <summary>
	/// 
	/// </summary>
	public interface IfcGeometricSetSelect{
	    /// <summary>
	    /// Dimension of the IfcGeometricSetSelect
	    /// </summary>
	    IfcDimensionCount1 Dim{
	        get;
	    }
	}
}

