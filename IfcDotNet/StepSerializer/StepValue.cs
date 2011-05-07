﻿#region License
/*

Copyright 2010, Iain Sproat
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

namespace IfcDotNet.StepSerializer
{
    /// <summary>
    /// The property token, data type and data value of a Step entity as represented in a Step file.
    /// </summary>
    internal struct StepValue{
        private StepToken _token;
        private Object _value;
        private Type _valueType;
        
        public StepValue(StepToken token, Object val){
            this._token = token;
            this._value = val;
            if(this._value == null)
                this._valueType = null;
            else
                this._valueType = val.GetType();
        }
        
        public StepToken Token{
            get{ return this._token; }
        }
        public Object Value{
            get{ return this._value; }
        }
        public Type ValueType{
            get{ return this._valueType; }
        }
        
        public override string ToString()
        {
            string val = string.Empty;
            if(_value != null)
                val = _value.ToString();
            
            //deal with arrays
            IList<StepValue> sv = this._value as IList<StepValue>;
            if(sv != null){
                val = "[";
                for(int i = 0; i < sv.Count; i++){
                    val += sv[i].ToString();
                    if(i < sv.Count - 1)
                        val += ", ";
                }
                val += "]";
            }
            
            return string.Format("[StepValue Token={0}, Value={1}, ValueType={2}]", _token, val, _valueType);
        }

    }
}