using Newtonsoft.Json;

namespace tpmodul8_103022300153
{
    class CovidConfig
    {
        private const string ConfigFileName = "covid_config.json";
        public string satuan_suhu { get; set; } = "celcius";
        public int batas_hari_deman { get; set; } = 14;
        public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public static CovidConfig LoadConfig()
        {
            if (File.Exists(ConfigFileName))
            {
                string json = File.ReadAllText(ConfigFileName);
                return JsonConvert.DeserializeObject<CovidConfig>(json);
            }
            else
            {
                CovidConfig defaultConfig = new CovidConfig();
                defaultConfig.SaveConfig();
                return defaultConfig;
            }
        }

        public void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(ConfigFileName, json);
        }

        public void UbahSatuan()
        {
            if (satuan_suhu.ToLower() == "celcius")
            {
                satuan_suhu = "fahrenheit";
            }
            else
            {
                satuan_suhu = "celcius";
            }
            SaveConfig();
        }
    }
}
