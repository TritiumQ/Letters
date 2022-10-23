using System.IO;
using UnityEngine;

internal static class OptionUtility
{
    /// <summary>
    /// ƒ¨»œ≈‰÷√Œƒº˛¥¢¥Ê¬∑æ∂
    /// </summary>
    public static readonly string DefaultPath = Application.streamingAssetsPath + "/Option.json";

    public static bool SaveOptionDataToJson(OptionData data)
    {
        if(data == null) return false;
        string json = JsonUtility.ToJson(data);
        FileStream fs = new FileStream(DefaultPath, FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(json);
        sw.Flush();
        sw.Close();
        fs.Close();
        return true;
    }

    public static OptionData LoadOptionDataFromJson()
    {
        OptionData optionData = null;
        FileStream fs = new FileStream(DefaultPath, FileMode.Open, FileAccess.Read);
        string json = string.Empty;
        if(fs.CanRead)
        {
			StreamReader sr = new StreamReader(fs);
            json = sr.ReadToEnd();
            if(json != string.Empty)
            {
                JsonUtility.FromJsonOverwrite(json, optionData);
            }
		}
        return optionData;
    }

	#region ƒ¨»œ≈‰÷√
	public static readonly bool DefaultEnableAudio = true;
	public static readonly float DefaultGlobalVolume = 50f;
	public static readonly float DefaultMusicVolume = 50f;
	public static readonly float DefaultEffectVolume = 50f;

	public static readonly ResolutionOption DefaultResolution = ResolutionOption.r1920x1080;
	public static readonly RefreshRateOption DefaultRefreshRate = RefreshRateOption.r60;
	public static readonly bool DefaultFullScreen = true;
	#endregion

}


