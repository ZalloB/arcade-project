using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Game.Settings
{
    public class OptionsManager : MonoBehaviour {

        public Toggle fullScreenToggle;
        public Dropdown resolutionDropdown;
        public Dropdown textureQualityDropdown;
        public Dropdown antialiasingDropdown;
        public Dropdown vSyncDropdown;

        public Slider masterVolumeSlider;
        public Slider musicVolumeSlider;
        public Slider sfxVolumeSlider;
        public Slider ambientVolumeSlider;
        public Slider playerVolumeSlider;

        public Resolution[] resolutions;
        public Options gameSettings;

        public AudioMixer AudioMixer;

        void OnEnable()
        {
            gameSettings = new Options();
            fullScreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
            resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
            textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
            antialiasingDropdown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
            vSyncDropdown.onValueChanged.AddListener(delegate { OnVsyncChange(); });

            masterVolumeSlider.onValueChanged.AddListener(delegate { OnMasterVolumeChange(); });
            musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
            sfxVolumeSlider.onValueChanged.AddListener(delegate { OnSfxVolumeChange(); });
            ambientVolumeSlider.onValueChanged.AddListener(delegate { OnAmbientVolumeChange(); });
            playerVolumeSlider.onValueChanged.AddListener(delegate { OnPlayerVolumeChange(); });

            resolutions = Screen.resolutions;
            foreach (var resolution in resolutions) {
                resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
            }

            loadSettings();
        }

        public void OnFullscreenToggle()
        {
            gameSettings.fullScreen = Screen.fullScreen = fullScreenToggle.isOn;
        }

        public void OnResolutionChange()
        {
            Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
            gameSettings.resolutionIndex = resolutionDropdown.value;
        }
        public void OnTextureQualityChange()
        {
            QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
        }

        public void OnAntialiasingChange()
        {
            gameSettings.antialiasing = QualitySettings.antiAliasing = (int)Mathf.Pow(2, antialiasingDropdown.value);
        }

        public void OnVsyncChange()
        {
            QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
        }

        public void OnMasterVolumeChange()
        {
            gameSettings.masterVolume = masterVolumeSlider.value;
            AudioMixer.SetFloat("MasterVolume", masterVolumeSlider.value);
        }

        public void OnMusicVolumeChange()
        {
            gameSettings.musicVolume = musicVolumeSlider.value;
            AudioMixer.SetFloat("MusicVolume", musicVolumeSlider.value);
        }

        public void OnSfxVolumeChange()
        {
            gameSettings.sfxVolume = sfxVolumeSlider.value;
            AudioMixer.SetFloat("SfxVolume", sfxVolumeSlider.value);

        }
        public void OnAmbientVolumeChange()
        {
            gameSettings.ambientVolume = ambientVolumeSlider.value;
            AudioMixer.SetFloat("AmbientVolume", ambientVolumeSlider.value);
        }
        public void OnPlayerVolumeChange()
        {
            gameSettings.playerVolume = playerVolumeSlider.value;
            AudioMixer.SetFloat("PlayerVolume", playerVolumeSlider.value);
        }

        public void saveSettings()
        {
            string jsonData = JsonUtility.ToJson(gameSettings, true);
            File.WriteAllText(Application.persistentDataPath + "/gameSettings.json", jsonData);
        }

        public void loadSettings()
        {
            gameSettings = JsonUtility.FromJson<Options>(Application.persistentDataPath + "/gameSettings.json");

            fullScreenToggle.isOn = gameSettings.fullScreen;
            resolutionDropdown.value = gameSettings.resolutionIndex;
            resolutionDropdown.RefreshShownValue();
            textureQualityDropdown.value = gameSettings.textureQuality;
            antialiasingDropdown.value = gameSettings.antialiasing;
            vSyncDropdown.value = gameSettings.vSync;

            masterVolumeSlider.value = gameSettings.masterVolume;
            musicVolumeSlider.value = gameSettings.musicVolume;
            sfxVolumeSlider.value = gameSettings.sfxVolume;
            ambientVolumeSlider.value = gameSettings.ambientVolume;
            playerVolumeSlider.value = gameSettings.playerVolume;
        }
    }
}