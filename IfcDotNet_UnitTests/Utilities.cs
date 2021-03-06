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
using System.IO;

using IfcDotNet;
using IfcDotNet.Schema;
using IfcDotNet.StepSerializer;

using NUnit.Framework;

namespace IfcDotNet_UnitTests
{
    /// <summary>
    /// Utilities holds helper methods, particularly those for generating Ifc STEP strings and objects
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// The following IFC example is copyright buildingSmart International.
        /// http://www.iai-tech.org/developers/get-started/hello-world/example-1
        /// </summary>
        /// <returns></returns>
        public static string StepSmallWallExampleString(){
            return "ISO-10303-21;\r\n" +
                "HEADER;\r\n" +
                "FILE_DESCRIPTION(('ViewDefinition [CoordinationView, QuantityTakeOffAddOnView]'), '2;1');\r\n" +
                "FILE_NAME('example.ifc', '2008-08-01T21:53:56', ('Architect'), ('Building Designer Office'), 'IFC Engine DLL version 1.02 beta', 'IFC Engine DLL version 1.02 beta', 'The authorising person');\r\n" +
                "FILE_SCHEMA(('IFC2X3'));\r\n" +
                "ENDSEC;\r\n" +
                "DATA;\r\n" +
                "#1 = IFCPROJECT('3MD_HkJ6X2EwpfIbCFm0g_', #2, 'Default Project', 'Description of Default Project', $, $, $, (#20), #7);\r\n" +
                "#2 = IFCOWNERHISTORY(#3, #6, $, .ADDED., $, $, $, 1217620436);\r\n" +
                "#3 = IFCPERSONANDORGANIZATION(#4, #5, $);\r\n" +
                "#4 = IFCPERSON('ID001', 'Bonsma', 'Peter', $, $, $, $, $);\r\n" +
                "#5 = IFCORGANIZATION($, 'TNO', 'TNO Building Innovation', $, $);\r\n" +
                "#6 = IFCAPPLICATION(#5, '0.10', 'Test Application', 'TA 1001');\r\n" +
                "#7 = IFCUNITASSIGNMENT((#8, #9, #10, #11, #15, #16, #17, #18, #19));\r\n" +
                "#8 = IFCSIUNIT(*, .LENGTHUNIT., $, .METRE.);\r\n" +
                "#9 = IFCSIUNIT(*, .AREAUNIT., $, .SQUARE_METRE.);\r\n" +
                "#10 = IFCSIUNIT(*, .VOLUMEUNIT., $, .CUBIC_METRE.);\r\n" +
                "#11 = IFCCONVERSIONBASEDUNIT(#12, .PLANEANGLEUNIT., 'DEGREE', #13);\r\n" +
                "#12 = IFCDIMENSIONALEXPONENTS(0, 0, 0, 0, 0, 0, 0);\r\n" +
                "#13 = IFCMEASUREWITHUNIT(IFCPLANEANGLEMEASURE(0.01745), #14);\r\n" +
                "#14 = IFCSIUNIT(*, .PLANEANGLEUNIT., $, .RADIAN.);\r\n" +
                "#15 = IFCSIUNIT(*, .SOLIDANGLEUNIT., $, .STERADIAN.);\r\n" +
                "#16 = IFCSIUNIT(*, .MASSUNIT., $, .GRAM.);\r\n" +
                "#17 = IFCSIUNIT(*, .TIMEUNIT., $, .SECOND.);\r\n" +
                "#18 = IFCSIUNIT(*, .THERMODYNAMICTEMPERATUREUNIT., $, .DEGREE_CELSIUS.);\r\n" +
                "#19 = IFCSIUNIT(*, .LUMINOUSINTENSITYUNIT., $, .LUMEN.);\r\n" +
                "#20 = IFCGEOMETRICREPRESENTATIONCONTEXT($, 'Model', 3, 1E-05, #21, $);\r\n" +
                "#21 = IFCAXIS2PLACEMENT3D(#22, $, $);\r\n" +
                "#22 = IFCCARTESIANPOINT((0., 0., 0.));\r\n" +
                "#23 = IFCSITE('3rNg_N55v4CRBpQVbZJoHB', #2, 'Default Site', 'Description of Default Site', $, #24, $, $, .ELEMENT., (24, 28, 0), (54, 25, 0), $, $, $);\r\n" +
                "#24 = IFCLOCALPLACEMENT($, #25);\r\n" +
                "#25 = IFCAXIS2PLACEMENT3D(#26, #27, #28);\r\n" +
                "#26 = IFCCARTESIANPOINT((0., 0., 0.));\r\n" +
                "#27 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "#28 = IFCDIRECTION((1., 0., 0.));\r\n" +
                "#29 = IFCBUILDING('0yf_M5JZv9QQXly4dq_zvI', #2, 'Default Building', 'Description of Default Building', $, #30, $, $, .ELEMENT., $, $, $);\r\n" +
                "#30 = IFCLOCALPLACEMENT(#24, #31);\r\n" +
                "#31 = IFCAXIS2PLACEMENT3D(#32, #33, #34);\r\n" +
                "#32 = IFCCARTESIANPOINT((0., 0., 0.));\r\n" +
                "#33 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "#34 = IFCDIRECTION((1., 0., 0.));\r\n" +
                "#35 = IFCBUILDINGSTOREY('0C87kaqBXF$xpGmTZ7zxN$', #2, 'Default Building Storey', 'Description of Default Building Storey', $, #36, $, $, .ELEMENT., 0.);\r\n" +
                "#36 = IFCLOCALPLACEMENT(#30, #37);\r\n" +
                "#37 = IFCAXIS2PLACEMENT3D(#38, #39, #40);\r\n" +
                "#38 = IFCCARTESIANPOINT((0., 0., 0.));\r\n" +
                "#39 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "#40 = IFCDIRECTION((1., 0., 0.));\r\n" +
                "#41 = IFCRELAGGREGATES('2168U9nPH5xB3UpDx_uK11', #2, 'BuildingContainer', 'BuildingContainer for BuildingStories', #29, (#35));\r\n" +
                "#42 = IFCRELAGGREGATES('3JuhmQJDj9xPnAnWoNb94X', #2, 'SiteContainer', 'SiteContainer For Buildings', #23, (#29));\r\n" +
                "#43 = IFCRELAGGREGATES('1Nl_BIjGLBke9u_6U3IWlW', #2, 'ProjectContainer', 'ProjectContainer for Sites', #1, (#23));\r\n" +
                "#44 = IFCRELCONTAINEDINSPATIALSTRUCTURE('2O_dMuDnr1Ahv28oR6ZVpr', #2, 'Default Building', 'Contents of Building Storey', (#45, #124), #35);\r\n" +
                "#45 = IFCWALLSTANDARDCASE('3vB2YO$MX4xv5uCqZZG05x', #2, 'Wall xyz', 'Description of Wall', $, #46, #51, $);\r\n" +
                "#46 = IFCLOCALPLACEMENT(#36, #47);\r\n" +
                "#47 = IFCAXIS2PLACEMENT3D(#48, #49, #50);\r\n" +
                "#48 = IFCCARTESIANPOINT((0., 0., 0.));\r\n" +
                "#49 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "#50 = IFCDIRECTION((1., 0., 0.));\r\n" +
                "#51 = IFCPRODUCTDEFINITIONSHAPE($, $, (#79, #83));\r\n" +
                "#52 = IFCPROPERTYSET('18RtPv6efDwuUOMduCZ7rH', #2, 'Pset_WallCommon', $, (#53, #54, #55, #56, #57, #58, #59, #60, #61, #62));\r\n" +
                "#53 = IFCPROPERTYSINGLEVALUE('Reference', 'Reference', IFCTEXT(''), $);\r\n" +
                "#54 = IFCPROPERTYSINGLEVALUE('AcousticRating', 'AcousticRating', IFCTEXT(''), $);\r\n" +
                "#55 = IFCPROPERTYSINGLEVALUE('FireRating', 'FireRating', IFCTEXT(''), $);\r\n" +
                "#56 = IFCPROPERTYSINGLEVALUE('Combustible', 'Combustible', IFCBOOLEAN(.F.), $);\r\n" +
                "#57 = IFCPROPERTYSINGLEVALUE('SurfaceSpreadOfFlame', 'SurfaceSpreadOfFlame', IFCTEXT(''), $);\r\n" +
                "#58 = IFCPROPERTYSINGLEVALUE('ThermalTransmittance', 'ThermalTransmittance', IFCREAL(0.24), $);\r\n" +
                "#59 = IFCPROPERTYSINGLEVALUE('IsExternal', 'IsExternal', IFCBOOLEAN(.T.), $);\r\n" +
                "#60 = IFCPROPERTYSINGLEVALUE('ExtendToStructure', 'ExtendToStructure', IFCBOOLEAN(.F.), $);\r\n" +
                "#61 = IFCPROPERTYSINGLEVALUE('LoadBearing', 'LoadBearing', IFCBOOLEAN(.F.), $);\r\n" +
                "#62 = IFCPROPERTYSINGLEVALUE('Compartmentation', 'Compartmentation', IFCBOOLEAN(.F.), $);\r\n" +
                "#63 = IFCRELDEFINESBYPROPERTIES('3IxFuNHRvBDfMT6_FiWPEz', #2, $, $, (#45), #52);\r\n" +
                "#64 = IFCELEMENTQUANTITY('10m6qcXSj0Iu4RVOK1omPJ', #2, 'BaseQuantities', $, $, (#65, #66, #67, #68, #69, #70, #71, #72));\r\n" +
                "#65 = IFCQUANTITYLENGTH('Width', 'Width', $, 0.3);\r\n" +
                "#66 = IFCQUANTITYLENGTH('Lenght', 'Lenght', $, 5.);\r\n" +
                "#67 = IFCQUANTITYAREA('GrossSideArea', 'GrossSideArea', $, 11.5);\r\n" +
                "#68 = IFCQUANTITYAREA('NetSideArea', 'NetSideArea', $, 10.45);\r\n" +
                "#69 = IFCQUANTITYVOLUME('GrossVolume', 'GrossVolume', $, 3.45);\r\n" +
                "#70 = IFCQUANTITYVOLUME('NetVolume', 'NetVolume', $, 3.135);\r\n" +
                "#71 = IFCQUANTITYLENGTH('Height', 'Height', $, 2.3);\r\n" +
                "#72 = IFCQUANTITYAREA('GrossFootprintArea', 'GrossFootprintArea', $, 1.5);\r\n" +
                "#73 = IFCRELDEFINESBYPROPERTIES('0cpLgxVi9Ew8B08wF2Ql1w', #2, $, $, (#45), #64);\r\n" +
                "#74 = IFCRELASSOCIATESMATERIAL('2zeggBjk9A5wcc3k9CYqdL', #2, $, $, (#45), #75);\r\n" +
                "#75 = IFCMATERIALLAYERSETUSAGE(#76, .AXIS2., .POSITIVE., -0.15);\r\n" +
                "#76 = IFCMATERIALLAYERSET((#77), $);\r\n" +
                "#77 = IFCMATERIALLAYER(#78, 0.3, $);\r\n" +
                "#78 = IFCMATERIAL('Name of the material used for the wall');\r\n" +
                "#79 = IFCSHAPEREPRESENTATION(#20, 'Axis', 'Curve2D', (#80));\r\n" +
                "#80 = IFCPOLYLINE((#81, #82));\r\n" +
                "#81 = IFCCARTESIANPOINT((0., 0.15));\r\n" +
                "#82 = IFCCARTESIANPOINT((5., 0.15));\r\n" +
                "#83 = IFCSHAPEREPRESENTATION(#20, 'Body', 'SweptSolid', (#84));\r\n" +
                "#84 = IFCEXTRUDEDAREASOLID(#85, #92, #96, 2.3);\r\n" +
                "#85 = IFCARBITRARYCLOSEDPROFILEDEF(.AREA., $, #86);\r\n" +
                "#86 = IFCPOLYLINE((#87, #88, #89, #90, #91));\r\n" +
                "#87 = IFCCARTESIANPOINT((0., 0.));\r\n" +
                "#88 = IFCCARTESIANPOINT((0., 0.3));\r\n" +
                "#89 = IFCCARTESIANPOINT((5., 0.3));\r\n" +
                "#90 = IFCCARTESIANPOINT((5., 0.));\r\n" +
                "#91 = IFCCARTESIANPOINT((0., 0.));\r\n" +
                "#92 = IFCAXIS2PLACEMENT3D(#93, #94, #95);\r\n" +
                "#93 = IFCCARTESIANPOINT((0., 0., 0.));\r\n" +
                "#94 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "#95 = IFCDIRECTION((1., 0., 0.));\r\n" +
                "#96 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "#97 = IFCOPENINGELEMENT('2LcE70iQb51PEZynawyvuT', #2, 'Opening Element xyz', 'Description of Opening', $, #98, #103, $);\r\n" +
                "#98 = IFCLOCALPLACEMENT(#46, #99);\r\n" +
                "#99 = IFCAXIS2PLACEMENT3D(#100, #101, #102);\r\n" +
                "#100 = IFCCARTESIANPOINT((0.9, 0., 0.25));\r\n" +
                "#101 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "#102 = IFCDIRECTION((1., 0., 0.));\r\n" +
                "#103 = IFCPRODUCTDEFINITIONSHAPE($, $, (#110));\r\n" +
                "#104 = IFCELEMENTQUANTITY('2yDPSWYWf319fWaWWvPxwA', #2, 'BaseQuantities', $, $, (#105, #106, #107));\r\n" +
                "#105 = IFCQUANTITYLENGTH('Depth', 'Depth', $, 0.3);\r\n" +
                "#106 = IFCQUANTITYLENGTH('Height', 'Height', $, 1.4);\r\n" +
                "#107 = IFCQUANTITYLENGTH('Width', 'Width', $, 0.75);\r\n" +
                "#108 = IFCRELDEFINESBYPROPERTIES('2UEO1blXL9sPmb1AMeW7Ax', #2, $, $, (#97), #104);\r\n" +
                "#109 = IFCRELVOIDSELEMENT('3lR5koIT51Kwudkm5eIoTu', #2, $, $, #45, #97);\r\n" +
                "#110 = IFCSHAPEREPRESENTATION(#20, 'Body', 'SweptSolid', (#111));\r\n" +
                "#111 = IFCEXTRUDEDAREASOLID(#112, #119, #123, 1.4);\r\n" +
                "#112 = IFCARBITRARYCLOSEDPROFILEDEF(.AREA., $, #113);\r\n" +
                "#113 = IFCPOLYLINE((#114, #115, #116, #117, #118));\r\n" +
                "#114 = IFCCARTESIANPOINT((0., 0.));\r\n" +
                "#115 = IFCCARTESIANPOINT((0., 0.3));\r\n" +
                "#116 = IFCCARTESIANPOINT((0.75, 0.3));\r\n" +
                "#117 = IFCCARTESIANPOINT((0.75, 0.));\r\n" +
                "#118 = IFCCARTESIANPOINT((0., 0.));\r\n" +
                "#119 = IFCAXIS2PLACEMENT3D(#120, #121, #122);\r\n" +
                "#120 = IFCCARTESIANPOINT((0., 0., 0.));\r\n" +
                "#121 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "#122 = IFCDIRECTION((1., 0., 0.));\r\n" +
                "#123 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "#124 = IFCWINDOW('0LV8Pid0X3IA3jJLVDPidY', #2, 'Window xyz', 'Description of Window', $, #125, #130, $, 1.4, 0.75);\r\n" +
                "#125 = IFCLOCALPLACEMENT(#98, #126);\r\n" +
                "#126 = IFCAXIS2PLACEMENT3D(#127, #128, #129);\r\n" +
                "#127 = IFCCARTESIANPOINT((0., 0.1, 0.));\r\n" +
                "#128 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "#129 = IFCDIRECTION((1., 0., 0.));\r\n" +
                "#130 = IFCPRODUCTDEFINITIONSHAPE($, $, (#150));\r\n" +
                "#131 = IFCRELFILLSELEMENT('1CDlLMVMv1qw1giUXpQgxI', #2, $, $, #97, #124);\r\n" +
                "#132 = IFCPROPERTYSET('0fhz_bHU54xB$tXHjHPUZl', #2, 'Pset_WindowCommon', $, (#133, #134, #135, #136, #137, #138, #139, #140, #141, #142, #143, #144));\r\n" +
                "#133 = IFCPROPERTYSINGLEVALUE('Reference', 'Reference', IFCTEXT(''), $);\r\n" +
                "#134 = IFCPROPERTYSINGLEVALUE('FireRating', 'FireRating', IFCTEXT(''), $);\r\n" +
                "#135 = IFCPROPERTYSINGLEVALUE('AcousticRating', 'AcousticRating', IFCTEXT(''), $);\r\n" +
                "#136 = IFCPROPERTYSINGLEVALUE('SecurityRating', 'SecurityRating', IFCTEXT(''), $);\r\n" +
                "#137 = IFCPROPERTYSINGLEVALUE('IsExternal', 'IsExternal', IFCBOOLEAN(.T.), $);\r\n" +
                "#138 = IFCPROPERTYSINGLEVALUE('Infiltration', 'Infiltration', IFCBOOLEAN(.F.), $);\r\n" +
                "#139 = IFCPROPERTYSINGLEVALUE('ThermalTransmittance', 'ThermalTransmittance', IFCREAL(0.24), $);\r\n" +
                "#140 = IFCPROPERTYSINGLEVALUE('GlazingAresFraction', 'GlazingAresFraction', IFCREAL(0.7), $);\r\n" +
                "#141 = IFCPROPERTYSINGLEVALUE('HandicapAccessible', 'HandicapAccessible', IFCBOOLEAN(.F.), $);\r\n" +
                "#142 = IFCPROPERTYSINGLEVALUE('FireExit', 'FireExit', IFCBOOLEAN(.F.), $);\r\n" +
                "#143 = IFCPROPERTYSINGLEVALUE('SelfClosing', 'SelfClosing', IFCBOOLEAN(.F.), $);\r\n" +
                "#144 = IFCPROPERTYSINGLEVALUE('SmokeStop', 'SmokeStop', IFCBOOLEAN(.F.), $);\r\n" +
                "#145 = IFCRELDEFINESBYPROPERTIES('2fHMxamlj5DvGvEKfCk8nj', #2, $, $, (#124), #132);\r\n" +
                "#146 = IFCELEMENTQUANTITY('0bB_7AP5v5OBZ90TDvo0Fo', #2, 'BaseQuantities', $, $, (#147, #148));\r\n" +
                "#147 = IFCQUANTITYLENGTH('Height', 'Height', $, 1.4);\r\n" +
                "#148 = IFCQUANTITYLENGTH('Width', 'Width', $, 0.75);\r\n" +
                "#149 = IFCRELDEFINESBYPROPERTIES('0FmgI0DRX49OXL_$Wa2P1E', #2, $, $, (#124), #146);\r\n" +
                "#150 = IFCSHAPEREPRESENTATION(#20, 'Body', 'SweptSolid', (#151));\r\n" +
                "#151 = IFCEXTRUDEDAREASOLID(#152, #159, #163, 1.4);\r\n" +
                "#152 = IFCARBITRARYCLOSEDPROFILEDEF(.AREA., $, #153);\r\n" +
                "#153 = IFCPOLYLINE((#154, #155, #156, #157, #158));\r\n" +
                "#154 = IFCCARTESIANPOINT((0., 0.));\r\n" +
                "#155 = IFCCARTESIANPOINT((0., 0.1));\r\n" +
                "#156 = IFCCARTESIANPOINT((0.75, 0.1));\r\n" +
                "#157 = IFCCARTESIANPOINT((0.75, 0.));\r\n" +
                "#158 = IFCCARTESIANPOINT((0., 0.));\r\n" +
                "#159 = IFCAXIS2PLACEMENT3D(#160, #161, #162);\r\n" +
                "#160 = IFCCARTESIANPOINT((0., 0., 0.));\r\n" +
                "#161 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "#162 = IFCDIRECTION((1., 0., 0.));\r\n" +
                "#163 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "ENDSEC;\r\n" +
                "END-ISO-10303-21;";
        }
        
        
        public static iso_10303 buildFailingMinimumExampleObject(){
            iso_10303 iso10303                               = new iso_10303();
            
            iso10303.uos                                        = new uos1();
            iso10303.uos.configuration                          = new string[]{"i-ifc2x3"};
            
            iso10303.version                                    = "2.0";
            
            iso10303.iso_10303_28_header                        = new iso_10303_28_header();
            iso10303.iso_10303_28_header.author                 = "John Hancock";
            iso10303.iso_10303_28_header.organization           = "MegaCorp";
            iso10303.iso_10303_28_header.time_stamp             = new DateTime(2010,11,12,13,04,00);
            iso10303.iso_10303_28_header.name                   = "An Example";
            iso10303.iso_10303_28_header.preprocessor_version   = "a preprocessor";
            iso10303.iso_10303_28_header.originating_system     = "IfcDotNet Library";
            iso10303.iso_10303_28_header.authorization          = "none";
            iso10303.iso_10303_28_header.documentation          = "documentation";

            IfcOrganization organization                        = new IfcOrganization();
            organization.entityid                               = "i1101";
            organization.Name                                   = "MegaCorp";

            IfcCartesianPoint point                             = new IfcCartesianPoint("i101", 2500, 0, 0);

            IfcDirection dir                                    = new IfcDirection("i102",0,1,0);

            ((uos1)iso10303.uos).Items                          = new Entity[]{organization, point, dir};

            return iso10303;
        }
        public static iso_10303 buildMinimumExampleObject(){
            iso_10303 iso = buildFailingMinimumExampleObject();
            iso.uos.id = "uos_1";
            return iso;
        }
        
        public static string IfcStepHeader(){
            return "ISO-10303-21;\r\n" +
                "HEADER;\r\n" +
                "FILE_DESCRIPTION(('ViewDefinition [CoordinationView, QuantityTakeOffAddOnView]'), '2;1');\r\n" +
                "FILE_NAME('example.ifc', '2008-08-01T21:53:56', ('Architect'), ('Building Designer Office'), 'IFC Engine DLL version 1.02 beta', 'IFC Engine DLL version 1.02 beta', 'The authorising person');\r\n" +
                "FILE_SCHEMA(('IFC2X3'));\r\n" +
                "ENDSEC;\r\n" +
                "DATA;\r\n";
        }
        
        public static string IfcStepEnd(){
            return "ENDSEC;\r\n" +
                "END-ISO-10303-21;";
        }
        
        public static string StepNoDataString(){
            return Utilities.IfcStepHeader() + Utilities.IfcStepEnd();
        }
        
        /// <summary>
        /// Not valid Ifc, but is valid STEP
        /// </summary>
        /// <returns></returns>
        public static string StepSimpleLineString(){
            return Utilities.IfcStepHeader() +
                "#1 = IFCQUANTITYLENGTH('Depth', 'Depth', $, 0.3);\r\n" +
                Utilities.IfcStepEnd();
        }
        
        public static string StepArrayString(){
            return Utilities.IfcStepHeader() +
                "#1 = IFCCARTESIANPOINT((0., 1., 4.5));\r\n" +
                Utilities.IfcStepEnd();
        }
        
        public static string StepWithReferenceString(){
            return Utilities.IfcStepHeader() +
                "#1 = IFCAXIS2PLACEMENT3D(#2, #3, #4);\r\n" +
                "#2 = IFCCARTESIANPOINT((0.9, 0., 0.25));\r\n" +
                "#3 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "#4 = IFCDIRECTION((1., 0., 0.));\r\n" +
                Utilities.IfcStepEnd();
        }
        
        public static string StepArrayWithReferencesString(){
            return Utilities.IfcStepHeader() +
                "#1 = IFCPOLYLINE((#2, #3, #4, #5, #6));\r\n" +
                "#2 = IFCCARTESIANPOINT((0., 0.));\r\n" +
                "#3 = IFCCARTESIANPOINT((0., 0.3));\r\n" +
                "#4 = IFCCARTESIANPOINT((0.75, 0.3));\r\n" +
                "#5 = IFCCARTESIANPOINT((0.75, 0.));\r\n" +
                "#6 = IFCCARTESIANPOINT((0., 0.));\r\n" +
                Utilities.IfcStepEnd();
        }
        
        public static string StepComplexReferencesString(){
            return Utilities.IfcStepHeader() +
                "#1 = IFCBUILDINGSTOREY('0C87kaqBXF$xpGmTZ7zxN$', $, 'Default Building Storey', 'Description of Default Building Storey', $, $, $, $, .ELEMENT., 0.);\r\n" +
                "#2 = IFCRELCONTAINEDINSPATIALSTRUCTURE('2O_dMuDnr1Ahv28oR6ZVpr', $, 'Default Building', 'Contents of Building Storey', (#3, #4), #1);\r\n" +
                "#3 = IFCWALLSTANDARDCASE('3vB2YO$MX4xv5uCqZZG05x', $, 'Wall xyz', 'Description of Wall', $, $, $, $);\r\n" +
                "#4 = IFCWINDOW('0LV8Pid0X3IA3jJLVDPidY', $, 'Window xyz', 'Description of Window', $, $, $, $, 1.4, 0.75);\r\n" +
                Utilities.IfcStepEnd();
        }
        
        public static string StepNestedObjectsString(){
            return Utilities.IfcStepHeader() +
                "#1 = IFCPROPERTYSINGLEVALUE('Reference', 'Reference', IFCTEXT('foobar'), $);\r\n" +
                Utilities.IfcStepEnd();
        }
        
        public static string StepNestedObjectWithinArrayString(){
            return Utilities.IfcStepHeader() +
                "#29409= IFCPROPERTYENUMERATEDVALUE('TopOrBottomEdge',$,(IFCTEXT('bottom_edge')),$);\r\n" +
                Utilities.IfcStepEnd();
        }
        
        public static string StepSelectString(){
        	return Utilities.IfcStepHeader() +
        		"#1 = IFCSIUNIT(*, .PLANEANGLEUNIT., $, .RADIAN.);\r\n" +
        		"#2 = IFCMEASUREWITHUNIT(IFCPLANEANGLEMEASURE(0.01745), #1);\r\n" +
        		Utilities.IfcStepEnd();
        }
        
        public static string StepArrayWrapperString(){
        	return Utilities.IfcStepHeader() +
        		"#1 = IFCOWNERHISTORY(#2, #5, $, .ADDED., $, $, $, 1217620436);\r\n" +
                "#2 = IFCPERSONANDORGANIZATION(#3, #4, $);\r\n" +
                "#3 = IFCPERSON('ID001', 'Bonsma', 'Peter', $, $, $, $, $);\r\n" +
                "#4 = IFCORGANIZATION($, 'TNO', 'TNO Building Innovation', $, $);\r\n" +
                "#5 = IFCAPPLICATION(#4, '0.10', 'Test Application', 'TA 1001');\r\n" +
        		"#6 = IFCLOCALPLACEMENT($, #7);\r\n" +
                "#7 = IFCAXIS2PLACEMENT3D(#8, #9, #10);\r\n" +
                "#8 = IFCCARTESIANPOINT((0., 0., 0.));\r\n" +
                "#9 = IFCDIRECTION((0., 0., 1.));\r\n" +
                "#10 = IFCDIRECTION((1., 0., 0.));\r\n" +
        		"#11 = IFCSITE('3rNg_N55v4CRBpQVbZJoHB', #1, 'Default Site', 'Description of Default Site', $, #6, $, $, .ELEMENT., (24, 28, 0), (54, 25, 0), $, $, $);\r\n" +
        		Utilities.IfcStepEnd();
        }
        
        public static void AssertIsMinimumExample(iso_10303 iso10303){
            Assert.IsNotNull(iso10303);
            Assert.IsNotNull(iso10303.iso_10303_28_header);
            Assert.AreEqual("An Example",                       iso10303.iso_10303_28_header.name);
            Assert.AreEqual(new DateTime(2010,11,12,13,04,00),  iso10303.iso_10303_28_header.time_stamp);
            Assert.AreEqual("John Hancock",                     iso10303.iso_10303_28_header.author);
            Assert.AreEqual("MegaCorp",                         iso10303.iso_10303_28_header.organization);
            Assert.AreEqual("IfcDotNet Library",                iso10303.iso_10303_28_header.originating_system);
            Assert.AreEqual("a preprocessor",                   iso10303.iso_10303_28_header.preprocessor_version);
            Assert.AreEqual("documentation",                    iso10303.iso_10303_28_header.documentation);
            Assert.AreEqual("none",                             iso10303.iso_10303_28_header.authorization);
            
            Assert.IsNotNull(iso10303.uos, "iso10303.uos is null");
            uos uos = iso10303.uos;
            Assert.AreEqual("uos_1",    uos.id);
            Assert.IsNotNull(uos.configuration, "iso10303.uos.configuration is null");
            Assert.AreEqual(1, uos.configuration.Length, "uos.configuration does not have 1 item in it");
            Assert.AreEqual("i-ifc2x3", uos.configuration[0]);
            
            Assert.IsNotNull(uos as uos1, "uos cannot be converted to uos1");
            uos1 uos1 = uos as uos1;
            
            Assert.IsNotNull(uos1, "uos1 is null");
            Assert.IsNotNull(uos1.Items, "uos1.items is null");
            Assert.AreEqual(3, uos1.Items.Length, "uos1.Items does not have 3 items in it");
            
            IfcOrganization org = uos1.Items[0] as IfcOrganization;
            Assert.IsNotNull( org , "org is null");
            Assert.AreEqual( "i1101", org.entityid , "entityid is not i1101");
            Assert.AreEqual("MegaCorp", org.Name );
            
            IfcCartesianPoint pnt = uos1.Items[1] as IfcCartesianPoint;
            Assert.IsNotNull( pnt, "pnt is null");
            Assert.AreEqual( "i101", pnt.entityid );
            Assert.IsNotNull( pnt.Coordinates );
            Assert.IsNotNull( pnt.Coordinates.Items );
            Assert.AreEqual( 3, pnt.Coordinates.Items.Length );
            Assert.AreEqual( 2500, pnt.Coordinates[0].Value );//TODO shorten the number of properties needed to be called to get the value. pnt.Coordinates[0] would be perfect!
            Assert.AreEqual( 0, pnt.Coordinates[1].Value );
            Assert.AreEqual( 0, pnt.Coordinates[2].Value );
            
            IfcDirection dir = uos1.Items[2] as IfcDirection;
            Assert.IsNotNull( dir , "dir is null");
            Assert.AreEqual( "i102", dir.entityid );
            Assert.IsNotNull( dir.DirectionRatios );
            Assert.IsNotNull( dir.DirectionRatios.Items );
            Assert.AreEqual( 3, dir.DirectionRatios.Items.Length ); 
            Assert.AreEqual( 0, dir.DirectionRatios[0].Value );
            Assert.AreEqual( 1, dir.DirectionRatios[1].Value );
            Assert.AreEqual( 0, dir.DirectionRatios[0].Value );
        }
    }
}
