using Infraccional.ObjetoTransferencia.Infraccional.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraccional.Negocio.Infraccional.Negocio.Clases
{
    /// <summary>
    /// Descripcion: Mapeo de elementos genericos.
    /// </summary>
    internal class Mapeo
    {
        /// <summary>
        /// Diccionario de mapeo region.
        /// </summary>
        private Dictionary<string, string> RegionMap;
        private Dictionary<string, string> ComunaMap;
        private Dictionary<string, string> OficinaMap;
        private Dictionary<string, string> MateriaMap;
        private Dictionary<string, string> SubMateriaMap;

        /// <summary>
        /// Constructor
        /// </summary>
        public Mapeo()
        {
            ConfiguracionRegion();
            ConfiguracionComuna();
            ConfiguracionOficna();
            ConfiguracionMapMateria();
            ConfiguracionMapSubMateria();
        }

        #region Configuracion Regionalizacion.

        /// <summary>
        /// Metodo que configura la region.
        /// </summary>
        private void ConfiguracionRegion()
        {
            RegionMap = new Dictionary<string, string>();
            RegionMap.Add("1", "01");
            RegionMap.Add("2", "02");
            RegionMap.Add("3", "03");
            RegionMap.Add("4", "04");
            RegionMap.Add("5", "05");
            RegionMap.Add("6", "06");
            RegionMap.Add("7", "07");
            RegionMap.Add("8", "08");
            RegionMap.Add("9", "09");
            RegionMap.Add("10", "10");
            RegionMap.Add("11", "11");
            RegionMap.Add("12", "12");
            RegionMap.Add("13", "13");
            RegionMap.Add("14", "14");
            RegionMap.Add("15", "15");
            RegionMap.Add("16", "16");
        }

        private void ConfiguracionComuna()
        {
            ComunaMap = new Dictionary<string, string>();
            ComunaMap.Add("1101", "010101");
            ComunaMap.Add("1107", "010107");
            ComunaMap.Add("1401", "010401");
            ComunaMap.Add("1402", "010402");
            ComunaMap.Add("1403", "010403");
            ComunaMap.Add("1404", "010404");
            ComunaMap.Add("1405", "010405");
            ComunaMap.Add("2101", "020101");
            ComunaMap.Add("2102", "020102");
            ComunaMap.Add("2103", "020103");
            ComunaMap.Add("2104", "020104");
            ComunaMap.Add("2201", "020201");
            ComunaMap.Add("2202", "020202");
            ComunaMap.Add("2203", "020203");
            ComunaMap.Add("2301", "020301");
            ComunaMap.Add("2302", "020302");
            ComunaMap.Add("3101", "030101");
            ComunaMap.Add("3102", "030102");
            ComunaMap.Add("3103", "030103");
            ComunaMap.Add("3201", "030201");
            ComunaMap.Add("3202", "030202");
            ComunaMap.Add("3301", "030301");
            ComunaMap.Add("3302", "030302");
            ComunaMap.Add("3303", "030303");
            ComunaMap.Add("3304", "030304");
            ComunaMap.Add("4101", "040101");
            ComunaMap.Add("4102", "040102");
            ComunaMap.Add("4103", "040103");
            ComunaMap.Add("4104", "040104");
            ComunaMap.Add("4105", "040105");
            ComunaMap.Add("4106", "040106");
            ComunaMap.Add("4201", "040201");
            ComunaMap.Add("4202", "040202");
            ComunaMap.Add("4203", "040203");
            ComunaMap.Add("4204", "040204");
            ComunaMap.Add("4301", "040301");
            ComunaMap.Add("4302", "040302");
            ComunaMap.Add("4303", "040303");
            ComunaMap.Add("4304", "040304");
            ComunaMap.Add("4305", "040305");
            ComunaMap.Add("5101", "050101");
            ComunaMap.Add("5102", "050102");
            ComunaMap.Add("5103", "050103");
            ComunaMap.Add("5104", "050104");
            ComunaMap.Add("5105", "050105");
            ComunaMap.Add("5107", "050107");
            ComunaMap.Add("5109", "050109");
            ComunaMap.Add("5201", "050201");
            ComunaMap.Add("5301", "050301");
            ComunaMap.Add("5302", "050302");
            ComunaMap.Add("5303", "050303");
            ComunaMap.Add("5304", "050304");
            ComunaMap.Add("5401", "050401");
            ComunaMap.Add("5402", "050402");
            ComunaMap.Add("5403", "050403");
            ComunaMap.Add("5404", "050404");
            ComunaMap.Add("5405", "050405");
            ComunaMap.Add("5501", "050501");
            ComunaMap.Add("5502", "050502");
            ComunaMap.Add("5503", "050503");
            ComunaMap.Add("5504", "050504");
            ComunaMap.Add("5506", "050506");
            ComunaMap.Add("5601", "050601");
            ComunaMap.Add("5602", "050602");
            ComunaMap.Add("5603", "050603");
            ComunaMap.Add("5604", "050604");
            ComunaMap.Add("5605", "050605");
            ComunaMap.Add("5606", "050606");
            ComunaMap.Add("5701", "050701");
            ComunaMap.Add("5702", "050702");
            ComunaMap.Add("5703", "050703");
            ComunaMap.Add("5704", "050704");
            ComunaMap.Add("5705", "050705");
            ComunaMap.Add("5706", "050706");

            ComunaMap.Add("5801", "050106");
            ComunaMap.Add("5802", "050505");
            ComunaMap.Add("5803", "050507");
            ComunaMap.Add("5804", "050108");

            ComunaMap.Add("6101", "060101");
            ComunaMap.Add("6102", "060102");
            ComunaMap.Add("6103", "060103");
            ComunaMap.Add("6104", "060104");
            ComunaMap.Add("6105", "060105");
            ComunaMap.Add("6106", "060106");
            ComunaMap.Add("6107", "060107");
            ComunaMap.Add("6108", "060108");
            ComunaMap.Add("6109", "060109");
            ComunaMap.Add("6110", "060110");
            ComunaMap.Add("6111", "060111");
            ComunaMap.Add("6112", "060112");
            ComunaMap.Add("6113", "060113");
            ComunaMap.Add("6114", "060114");
            ComunaMap.Add("6115", "060115");
            ComunaMap.Add("6116", "060116");
            ComunaMap.Add("6117", "060117");
            ComunaMap.Add("6201", "060201");
            ComunaMap.Add("6202", "060202");
            ComunaMap.Add("6203", "060203");
            ComunaMap.Add("6204", "060204");
            ComunaMap.Add("6205", "060205");
            ComunaMap.Add("6206", "060206");
            ComunaMap.Add("6301", "060301");
            ComunaMap.Add("6302", "060302");
            ComunaMap.Add("6303", "060303");
            ComunaMap.Add("6304", "060304");
            ComunaMap.Add("6305", "060305");
            ComunaMap.Add("6306", "060306");
            ComunaMap.Add("6307", "060307");
            ComunaMap.Add("6308", "060308");
            ComunaMap.Add("6309", "060309");
            ComunaMap.Add("6310", "060310");
            ComunaMap.Add("7101", "070101");
            ComunaMap.Add("7102", "070102");
            ComunaMap.Add("7103", "070103");
            ComunaMap.Add("7104", "070104");
            ComunaMap.Add("7105", "070105");
            ComunaMap.Add("7106", "070106");
            ComunaMap.Add("7107", "070107");
            ComunaMap.Add("7108", "070108");
            ComunaMap.Add("7109", "070109");
            ComunaMap.Add("7110", "070110");
            ComunaMap.Add("7201", "070201");
            ComunaMap.Add("7202", "070202");
            ComunaMap.Add("7203", "070203");
            ComunaMap.Add("7301", "070301");
            ComunaMap.Add("7302", "070302");
            ComunaMap.Add("7303", "070303");
            ComunaMap.Add("7304", "070304");
            ComunaMap.Add("7305", "070305");
            ComunaMap.Add("7306", "070306");
            ComunaMap.Add("7307", "070307");
            ComunaMap.Add("7308", "070308");
            ComunaMap.Add("7309", "070309");
            ComunaMap.Add("7401", "070401");
            ComunaMap.Add("7402", "070402");
            ComunaMap.Add("7403", "070403");
            ComunaMap.Add("7404", "070404");
            ComunaMap.Add("7405", "070405");
            ComunaMap.Add("7406", "070406");
            ComunaMap.Add("7407", "070407");
            ComunaMap.Add("7408", "070408");
            ComunaMap.Add("8101", "080101");
            ComunaMap.Add("8102", "080102");
            ComunaMap.Add("8103", "080103");
            ComunaMap.Add("8104", "080104");
            ComunaMap.Add("8105", "080105");
            ComunaMap.Add("8106", "080106");
            ComunaMap.Add("8107", "080107");
            ComunaMap.Add("8108", "080108");
            ComunaMap.Add("8109", "080109");
            ComunaMap.Add("8110", "080110");
            ComunaMap.Add("8111", "080111");
            ComunaMap.Add("8112", "080112");
            ComunaMap.Add("8201", "080201");
            ComunaMap.Add("8202", "080202");
            ComunaMap.Add("8203", "080203");
            ComunaMap.Add("8204", "080204");
            ComunaMap.Add("8205", "080205");
            ComunaMap.Add("8206", "080206");
            ComunaMap.Add("8207", "080207");
            ComunaMap.Add("8301", "080301");
            ComunaMap.Add("8302", "080302");
            ComunaMap.Add("8303", "080303");
            ComunaMap.Add("8304", "080304");
            ComunaMap.Add("8305", "080305");
            ComunaMap.Add("8306", "080306");
            ComunaMap.Add("8307", "080307");
            ComunaMap.Add("8308", "080308");
            ComunaMap.Add("8309", "080309");
            ComunaMap.Add("8310", "080310");
            ComunaMap.Add("8311", "080311");
            ComunaMap.Add("8312", "080312");
            ComunaMap.Add("8313", "080313");
            ComunaMap.Add("8314", "080314");
            // Se cambia este mapeo, ya que al agregar la regón de ñuble cambiaron
            ComunaMap.Add("16101", "80401");
            ComunaMap.Add("16102", "80402");
            ComunaMap.Add("16103", "80406");
            ComunaMap.Add("16104", "80407");
            ComunaMap.Add("16105", "80410");
            ComunaMap.Add("16106", "80411");
            ComunaMap.Add("16107", "80413");
            ComunaMap.Add("16108", "80418");
            ComunaMap.Add("16109", "80421");
            ComunaMap.Add("16201", "80414");
            ComunaMap.Add("16202", "80403");
            ComunaMap.Add("16203", "80404");
            ComunaMap.Add("16204", "80408");
            ComunaMap.Add("16205", "80412");
            ComunaMap.Add("16206", "80415");
            ComunaMap.Add("16207", "80420");
            ComunaMap.Add("16301", "80416");
            ComunaMap.Add("16302", "80405");
            ComunaMap.Add("16303", "80409");
            ComunaMap.Add("16304", "80417");
            ComunaMap.Add("16305", "80419");

            ComunaMap.Add("9101", "090101");
            ComunaMap.Add("9102", "090102");
            ComunaMap.Add("9103", "090103");
            ComunaMap.Add("9104", "090104");
            ComunaMap.Add("9105", "090105");
            ComunaMap.Add("9106", "090106");
            ComunaMap.Add("9107", "090107");
            ComunaMap.Add("9108", "090108");
            ComunaMap.Add("9109", "090109");
            ComunaMap.Add("9110", "090110");
            ComunaMap.Add("9111", "090111");
            ComunaMap.Add("9112", "090112");
            ComunaMap.Add("9113", "090113");
            ComunaMap.Add("9114", "090114");
            ComunaMap.Add("9115", "090115");
            ComunaMap.Add("9116", "090116");
            ComunaMap.Add("9117", "090117");
            ComunaMap.Add("9118", "090118");
            ComunaMap.Add("9119", "090119");
            ComunaMap.Add("9120", "090120");
            ComunaMap.Add("9121", "090121");
            ComunaMap.Add("9201", "090201");
            ComunaMap.Add("9202", "090202");
            ComunaMap.Add("9203", "090203");
            ComunaMap.Add("9204", "090204");
            ComunaMap.Add("9205", "090205");
            ComunaMap.Add("9206", "090206");
            ComunaMap.Add("9207", "090207");
            ComunaMap.Add("9208", "090208");
            ComunaMap.Add("9209", "090209");
            ComunaMap.Add("9210", "090210");
            ComunaMap.Add("9211", "090211");
            ComunaMap.Add("10101", "100101");
            ComunaMap.Add("10102", "100102");
            ComunaMap.Add("10103", "100103");
            ComunaMap.Add("10104", "100104");
            ComunaMap.Add("10105", "100105");
            ComunaMap.Add("10106", "100106");
            ComunaMap.Add("10107", "100107");
            ComunaMap.Add("10108", "100108");
            ComunaMap.Add("10109", "100109");
            ComunaMap.Add("10201", "100201");
            ComunaMap.Add("10202", "100202");
            ComunaMap.Add("10203", "100203");
            ComunaMap.Add("10204", "100204");
            ComunaMap.Add("10205", "100205");
            ComunaMap.Add("10206", "100206");
            ComunaMap.Add("10207", "100207");
            ComunaMap.Add("10208", "100208");
            ComunaMap.Add("10209", "100209");
            ComunaMap.Add("10210", "100210");
            ComunaMap.Add("10301", "100301");
            ComunaMap.Add("10302", "100302");
            ComunaMap.Add("10303", "100303");
            ComunaMap.Add("10304", "100304");
            ComunaMap.Add("10305", "100305");
            ComunaMap.Add("10306", "100306");
            ComunaMap.Add("10307", "100307");
            ComunaMap.Add("10401", "100401");
            ComunaMap.Add("10402", "100402");
            ComunaMap.Add("10403", "100403");
            ComunaMap.Add("10404", "100404");
            ComunaMap.Add("11101", "110101");
            ComunaMap.Add("11102", "110102");
            ComunaMap.Add("11201", "110201");
            ComunaMap.Add("11202", "110202");
            ComunaMap.Add("11203", "110203");
            ComunaMap.Add("11301", "110301");
            ComunaMap.Add("11302", "110302");
            ComunaMap.Add("11303", "110303");
            ComunaMap.Add("11401", "110401");
            ComunaMap.Add("11402", "110402");
            ComunaMap.Add("12101", "120101");
            ComunaMap.Add("12102", "120102");
            ComunaMap.Add("12103", "120103");
            ComunaMap.Add("12104", "120104");
            ComunaMap.Add("12201", "120201");
            ComunaMap.Add("12202", "120202");
            ComunaMap.Add("12301", "120301");
            ComunaMap.Add("12302", "120302");
            ComunaMap.Add("12303", "120303");
            ComunaMap.Add("12401", "120401");
            ComunaMap.Add("12402", "120402");
            ComunaMap.Add("13101", "130101");
            ComunaMap.Add("13102", "130102");
            ComunaMap.Add("13103", "130103");
            ComunaMap.Add("13104", "130104");
            ComunaMap.Add("13105", "130105");
            ComunaMap.Add("13106", "130106");
            ComunaMap.Add("13107", "130107");
            ComunaMap.Add("13108", "130108");
            ComunaMap.Add("13109", "130109");
            ComunaMap.Add("13110", "130110");
            ComunaMap.Add("13111", "130111");
            ComunaMap.Add("13112", "130112");
            ComunaMap.Add("13113", "130113");
            ComunaMap.Add("13114", "130114");
            ComunaMap.Add("13115", "130115");
            ComunaMap.Add("13116", "130116");
            ComunaMap.Add("13117", "130117");
            ComunaMap.Add("13118", "130118");
            ComunaMap.Add("13119", "130119");
            ComunaMap.Add("13120", "130120");
            ComunaMap.Add("13121", "130121");
            ComunaMap.Add("13122", "130122");
            ComunaMap.Add("13123", "130123");
            ComunaMap.Add("13124", "130124");
            ComunaMap.Add("13125", "130125");
            ComunaMap.Add("13126", "130126");
            ComunaMap.Add("13127", "130127");
            ComunaMap.Add("13128", "130128");
            ComunaMap.Add("13129", "130129");
            ComunaMap.Add("13130", "130130");
            ComunaMap.Add("13131", "130131");
            ComunaMap.Add("13132", "130132");
            ComunaMap.Add("13201", "130201");
            ComunaMap.Add("13202", "130202");
            ComunaMap.Add("13203", "130203");
            ComunaMap.Add("13301", "130301");
            ComunaMap.Add("13302", "130302");
            ComunaMap.Add("13303", "130303");
            ComunaMap.Add("13401", "130401");
            ComunaMap.Add("13402", "130402");
            ComunaMap.Add("13403", "130403");
            ComunaMap.Add("13404", "130404");
            ComunaMap.Add("13501", "130501");
            ComunaMap.Add("13502", "130502");
            ComunaMap.Add("13503", "130503");
            ComunaMap.Add("13504", "130504");
            ComunaMap.Add("13505", "130505");
            ComunaMap.Add("13601", "130601");
            ComunaMap.Add("13602", "130602");
            ComunaMap.Add("13603", "130603");
            ComunaMap.Add("13604", "130604");
            ComunaMap.Add("13605", "130605");
            ComunaMap.Add("14101", "140101");
            ComunaMap.Add("14102", "140102");
            ComunaMap.Add("14103", "140103");
            ComunaMap.Add("14104", "140104");
            ComunaMap.Add("14105", "140105");
            ComunaMap.Add("14106", "140106");
            ComunaMap.Add("14107", "140107");
            ComunaMap.Add("14108", "140108");
            ComunaMap.Add("14201", "140201");
            ComunaMap.Add("14202", "140202");
            ComunaMap.Add("14203", "140203");
            ComunaMap.Add("14204", "140204");
            ComunaMap.Add("15101", "150101");
            ComunaMap.Add("15102", "150102");
            ComunaMap.Add("15201", "150201");
            ComunaMap.Add("15202", "150202");


        }

        private void ConfiguracionOficna()
        {
            OficinaMap = new Dictionary<string, string>();
            OficinaMap.Add("3", "113");
            OficinaMap.Add("4", "186");
            OficinaMap.Add("5", "97");
            OficinaMap.Add("6", "111");
            OficinaMap.Add("7", "109");
            OficinaMap.Add("8", "153");
            OficinaMap.Add("9", "112");
            OficinaMap.Add("10", "105");
            OficinaMap.Add("11", "115");
            OficinaMap.Add("12", "146");
            OficinaMap.Add("14", "114");
            OficinaMap.Add("15", "117");
            OficinaMap.Add("16", "127");
            OficinaMap.Add("13", "130");
            OficinaMap.Add("17", "134");
            OficinaMap.Add("18", "136");
            OficinaMap.Add("19", "131");
            OficinaMap.Add("20", "138");
            OficinaMap.Add("22", "137");
            OficinaMap.Add("21", "139");
            OficinaMap.Add("23", "190");
            OficinaMap.Add("24", "189");
            OficinaMap.Add("25", "110");
            OficinaMap.Add("26", "116");
            OficinaMap.Add("27", "191");
            OficinaMap.Add("28", "108");
            OficinaMap.Add("65", "141");
            OficinaMap.Add("29", "98");
            OficinaMap.Add("30", "118");
            OficinaMap.Add("31", "122");
            // Cambio en mapeo de oficinas de nueva region bulnes
            OficinaMap.Add("82", "104");
            OficinaMap.Add("84", "101");
            OficinaMap.Add("83", "135");

            OficinaMap.Add("35", "142");
            OficinaMap.Add("36", "123");
            OficinaMap.Add("37", "148");
            OficinaMap.Add("38", "95");
            OficinaMap.Add("39", "147");
            OficinaMap.Add("44", "128");
            OficinaMap.Add("45", "129");
            OficinaMap.Add("46", "102");
            OficinaMap.Add("47", "94");
            OficinaMap.Add("48", "124");
            OficinaMap.Add("49", "133");
            OficinaMap.Add("51", "107");
            OficinaMap.Add("52", "100");
            OficinaMap.Add("54", "106");
            OficinaMap.Add("56", "103");
            OficinaMap.Add("57", "119");
            OficinaMap.Add("58", "96");
            OficinaMap.Add("59", "143");
            OficinaMap.Add("60", "144");
            OficinaMap.Add("61", "93");
            OficinaMap.Add("62", "120");
            OficinaMap.Add("63", "121");
            OficinaMap.Add("64", "140");
            OficinaMap.Add("40", "145");
            OficinaMap.Add("41", "125");
            OficinaMap.Add("42", "192");
            OficinaMap.Add("43", "132");
            OficinaMap.Add("1", "99");
            OficinaMap.Add("2", "193");
        }

        #endregion


        #region Configuracion Materia - SubMateria

        private void ConfiguracionMapMateria()
        {
            MateriaMap = new Dictionary<string, string>();

            MateriaMap.Add("1", "12");
            MateriaMap.Add("2", "11");
            MateriaMap.Add("3", "27");
            MateriaMap.Add("4", "19");
            MateriaMap.Add("5", "13");
            MateriaMap.Add("6", "1");
            MateriaMap.Add("7", "2");
            MateriaMap.Add("8", "3");
            MateriaMap.Add("9", "4");
            MateriaMap.Add("10", "24");
            MateriaMap.Add("11", "25");
            MateriaMap.Add("12", "20");
            MateriaMap.Add("13", "21");
            MateriaMap.Add("14", "22");
            MateriaMap.Add("15", "23");
            MateriaMap.Add("16", "18");
            MateriaMap.Add("17", "5");
            MateriaMap.Add("18", "6");
            MateriaMap.Add("19", "7");
            MateriaMap.Add("22", "26");


        }

        private void ConfiguracionMapSubMateria()
        {
            SubMateriaMap = new Dictionary<string, string>();

            SubMateriaMap.Add("35", "104");
            SubMateriaMap.Add("61", "182");
            SubMateriaMap.Add("64", "129");
            SubMateriaMap.Add("68", "133");
            SubMateriaMap.Add("72", "137");
            SubMateriaMap.Add("57", "180");
            SubMateriaMap.Add("39", "13");
            SubMateriaMap.Add("43", "15");
            SubMateriaMap.Add("38", "102");
            SubMateriaMap.Add("42", "120");
            SubMateriaMap.Add("44", "121");
            SubMateriaMap.Add("60", "181");
            SubMateriaMap.Add("25", "97");
            SubMateriaMap.Add("30", "171");
            SubMateriaMap.Add("26", "96");
            SubMateriaMap.Add("27", "95");
            SubMateriaMap.Add("22", "167");
            SubMateriaMap.Add("23", "168");
            SubMateriaMap.Add("24", "5");
            SubMateriaMap.Add("80", "188");
            SubMateriaMap.Add("36", "118");
            SubMateriaMap.Add("46", "17");
            SubMateriaMap.Add("51", "126");
            SubMateriaMap.Add("37", "173");
            SubMateriaMap.Add("41", "119");
            SubMateriaMap.Add("59", "178");
            SubMateriaMap.Add("63", "101");
            SubMateriaMap.Add("65", "130");
            SubMateriaMap.Add("69", "134");
            SubMateriaMap.Add("73", "138");
            SubMateriaMap.Add("66", "131");
            SubMateriaMap.Add("70", "135");
            SubMateriaMap.Add("74", "139");
            SubMateriaMap.Add("82", "190");
            SubMateriaMap.Add("62", "183");
            SubMateriaMap.Add("58", "177");
            SubMateriaMap.Add("48", "123");
            SubMateriaMap.Add("47", "122");
            SubMateriaMap.Add("31", "6");
            SubMateriaMap.Add("32", "92");
            SubMateriaMap.Add("33", "12");
            SubMateriaMap.Add("34", "172");
            SubMateriaMap.Add("49", "124");
            SubMateriaMap.Add("50", "125");
            SubMateriaMap.Add("81", "189");
            SubMateriaMap.Add("77", "185");
            SubMateriaMap.Add("79", "187");
            SubMateriaMap.Add("78", "186");
            SubMateriaMap.Add("76", "184");
            SubMateriaMap.Add("83", "191");
            SubMateriaMap.Add("45", "16");
            SubMateriaMap.Add("21", "7");
            SubMateriaMap.Add("28", "169");
            SubMateriaMap.Add("29", "170");
            SubMateriaMap.Add("40", "14");
            SubMateriaMap.Add("71", "132");
            SubMateriaMap.Add("75", "136");
            SubMateriaMap.Add("67", "140");
            SubMateriaMap.Add("84", "141");
            SubMateriaMap.Add("113", "150");
            SubMateriaMap.Add("86", "18");
            SubMateriaMap.Add("125", "156");
            SubMateriaMap.Add("87", "21");
            SubMateriaMap.Add("124", "155");
            SubMateriaMap.Add("100", "27");
            SubMateriaMap.Add("89", "127");
            SubMateriaMap.Add("104", "174");
            SubMateriaMap.Add("117", "147");
            SubMateriaMap.Add("90", "151");
            SubMateriaMap.Add("105", "144");
            SubMateriaMap.Add("118", "148");
            SubMateriaMap.Add("130", "152");
            SubMateriaMap.Add("99", "146");
            SubMateriaMap.Add("88", "143");
            SubMateriaMap.Add("129", "43");
            SubMateriaMap.Add("122", "153");
            SubMateriaMap.Add("101", "26");
            SubMateriaMap.Add("112", "36");
            SubMateriaMap.Add("106", "30");
            SubMateriaMap.Add("109", "33");
            SubMateriaMap.Add("108", "31");
            SubMateriaMap.Add("111", "34");
            SubMateriaMap.Add("110", "35");
            SubMateriaMap.Add("120", "44");
            SubMateriaMap.Add("91", "22");
            SubMateriaMap.Add("114", "38");
            SubMateriaMap.Add("115", "37");
            SubMateriaMap.Add("85", "142");
            SubMateriaMap.Add("92", "23");
            SubMateriaMap.Add("119", "40");
            SubMateriaMap.Add("103", "39");
            SubMateriaMap.Add("116", "211");
            SubMateriaMap.Add("93", "20");
            SubMateriaMap.Add("98", "193");
            SubMateriaMap.Add("121", "41");
            SubMateriaMap.Add("126", "159");
            SubMateriaMap.Add("131", "47");
            SubMateriaMap.Add("132", "46");
            SubMateriaMap.Add("133", "45");
            SubMateriaMap.Add("97", "25");
            SubMateriaMap.Add("94", "145");
            SubMateriaMap.Add("123", "154");
            SubMateriaMap.Add("102", "28");
            SubMateriaMap.Add("128", "42");
            SubMateriaMap.Add("127", "157");
            SubMateriaMap.Add("95", "24");
            SubMateriaMap.Add("96", "192");
            SubMateriaMap.Add("2", "210");
            SubMateriaMap.Add("1", "57");
            SubMateriaMap.Add("10", "198");
            SubMateriaMap.Add("20", "62");
            SubMateriaMap.Add("3", "109");
            SubMateriaMap.Add("6", "206");
            SubMateriaMap.Add("16", "204");
            SubMateriaMap.Add("12", "200");
            SubMateriaMap.Add("11", "199");
            SubMateriaMap.Add("18", "65");
            SubMateriaMap.Add("15", "203");
            SubMateriaMap.Add("9", "209");
            SubMateriaMap.Add("5", "29");
            SubMateriaMap.Add("8", "208");
            SubMateriaMap.Add("17", "205");
            SubMateriaMap.Add("13", "201");
            SubMateriaMap.Add("14", "202");
            SubMateriaMap.Add("19", "61");
            SubMateriaMap.Add("7", "207");
            SubMateriaMap.Add("4", "58");
            SubMateriaMap.Add("135", "196");
            SubMateriaMap.Add("134", "195");
            SubMateriaMap.Add("136", "158");
            SubMateriaMap.Add("52", "147");
            SubMateriaMap.Add("54", "175");
            SubMateriaMap.Add("55", "9");
            SubMateriaMap.Add("56", "98");
            SubMateriaMap.Add("107", "32");

        }

        #endregion


        #region Consultas Regionalizacion.

        /// <summary>
        /// Metodo que permite obtener el map de regiones.
        /// </summary>
        /// <param name="Key">Clave de region.</param>
        /// <returns></returns>
        public string ObtenerValueRegion(string keyRegion)
        {
            return RegionMap[keyRegion];
        }

        /// <summary>
        /// Metodo que permite obtener el map de comunas.
        /// </summary>
        /// <param name="keyComuna">Clave de comuna</param>
        /// <returns></returns>
        public string ObtenerValueComuna(string keyComuna)
        {
            return ComunaMap[keyComuna];
        }

        /// <summary>
        /// Metodo que permite obtener el map de oficinas.
        /// </summary>
        /// <param name="keyOficina"></param>
        /// <returns></returns>
        public string ObtenerValueOficina(string keyOficina)
        {
            return OficinaMap[keyOficina];
        }

        #endregion


        #region Consultas Materia - SubMateria

        /// <summary>
        /// Metodo que permite obtener la materia mapeada.
        /// </summary>
        /// <param name="keyMateria"></param>
        /// <returns></returns>
        public string ObtenerValueMateria(string keyMateria)
        {
            return MateriaMap[keyMateria];
        }

        /// <summary>
        /// Metodo que permite obtener la materia mapeada.
        /// </summary>
        /// <param name="keyMateria"></param>
        /// <returns></returns>
        public string ObtenerKeyMateria(string valueMateria)
        {
            return MateriaMap.First(m => m.Value.Equals(valueMateria)).Key;
        }

        /// <summary>
        /// Metodo que permite obtener la submeteria mapeada
        /// </summary>
        /// <param name="keySubMateria"></param>
        /// <returns></returns>
        public string ObtenerValueSubMateria(string keySubMateria)
        {
            return SubMateriaMap[keySubMateria];
        }

        /// <summary>
        /// Metodo que permite obtener la submateria por el valor.
        /// </summary>
        /// <param name="valueSubMateria"></param>
        /// <returns></returns>
        public string ObtenerKeySubMateria(string valueSubMateria)
        {
            return SubMateriaMap.First(s => s.Value.Equals(valueSubMateria)).Key;
        }


        #endregion

    }
}
