﻿// Copyright (c) 2016 Piotr Gwiazdowski. All rights reserved.
// This file is a part of Better Build Info project.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;
using UnityEditor;
using Better.BuildInfo.Internal;

namespace Better.BuildInfo
{
    public class BuildInfoSettings : ScriptableObject
    {
        public static BuildInfoSettings Instance
        {
            get { return BBI_Settings.GetInstance(false); }
        }


        public static void EnsureAsset()
        {
            BBI_Settings.GetInstance(true);
        }

        private static string GetSettingsKey(string key)
        {
            return "BBI_" + System.Environment.CurrentDirectory + "_" + key;
        }

        public static string ReportToOpen
        {
            get
            {
                return EditorPrefs.GetString(GetSettingsKey("ReportToOpen"), string.Empty);
            }
            set
            {
                var key = GetSettingsKey("ReportToOpen");
                if (string.IsNullOrEmpty(value))
                    EditorPrefs.DeleteKey(key);
                else
                    EditorPrefs.SetString(key, value);
            }
        }

        public static string LastDirectory
        {
            get { return EditorPrefs.GetString(GetSettingsKey("LastDirectory")); }
            set { EditorPrefs.SetString(GetSettingsKey("LastDirectory"), value); }
        }

        public static string[] RecentReports
        {
            get
            {
                var value = EditorPrefs.GetString(GetSettingsKey("LastReports"));
                if (string.IsNullOrEmpty(value))
                {
#pragma warning disable 0612
                    return Instance.recentReports;
#pragma warning restore 0612
                }
                return value.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            }
            set
            {
                EditorPrefs.SetString(GetSettingsKey("LastReports"), string.Join(";", value));
            }
        }

        public static float GetColumnWidth(string name)
        {
            return EditorPrefs.GetFloat("BBI_ColumnWidth_" + name, 100.0f);
        }

        public static void SetColumnWidth(string name, float value)
        {
            EditorPrefs.SetFloat("BBI_ColumnWidth_" + name, Mathf.Max(50.0f, value));
        }

        [Header("If enabled, the tool will automatically track every build you make")]
        public bool enabled = true;

        [Header("Check if you want a newly generated report to be opened automatically")]
        public bool autoOpenReportAfterBuild = false;

        [Header("Increases time & memory footprint during build, but collects", order = 0)]
        [Space(-10, order = 1)]
        [Header("extra info, such as texture format", order = 2)]
        public bool collectAssetsDetails = true;
        [Header("Experimental, needs above being enabled too. May be slow for big projects!", order = 0)]
        [Space(-10, order = 1)]
        [Header("Makes most sense for Android, because APK is basically a Zip archive.", order = 2)]
        public bool checkAssetsCompressedSize = false;

        public const string DateKey = "{date}";
        public const string TimeKey = "{time}";
        public const string BuildTargetKey = "{buildtarget}";
        public const string BuildDirKey = "{builddir}";
        public const string SvnRevisionKey = "{svnrev}";
        public const string GitHashKey = "{githash}";
        public const string GitShortHashKey = "{gitshash}";

        [Header("You can use environmental variables here or following properties:", order = 0)]
        [Space(-10, order = 1)]
        [Header(DateKey + " - date of the build (e.g. 2016-04-29)", order = 2)]
        [Space(-10, order = 3)]
        [Header(TimeKey + " - time of the build (e.g. 23-21-59)", order = 4)]
        [Space(-10, order = 5)]
        [Header(BuildTargetKey + " - build target (iOS, Android etc.)", order = 6)]
        [Space(-10, order = 7)]
        [Header(BuildDirKey + " - build directory", order = 8)]
        [Space(-10, order = 9)]
        [Header(SvnRevisionKey + " - svn revision number", order = 10)]
        [Space(-10, order = 11)]
        [Header(GitHashKey + " - git revision hash", order = 12)]
        [Space(-10, order = 13)]
        [Header(GitShortHashKey + " - git revision hash (short)", order = 14)]
        public string outputPath = "BuildReports/{buildtarget}_{date}_{time}.bbi";

        [Header("Reports generated during Unity Cloud Build seem to have to be placed")]
        [Space(-10, order = 1)]
        [Header("in the {builddir}, otherwise they don't get included in zips", order = 2)]
        public string cloudBuildOutputPath = "{builddir}/{buildtarget}_{date}_{time}.bbi";

        [Header("Enable if you want to select asset with a double click (single is the default)")]
        public bool doubleClickSelect = false;

        [Header("zipinfo is needed to analyze Android builds", order = 0)]
        [UnityEngine.Serialization.FormerlySerializedAs("ZipInfoPath")]
        public string ZipinfoPathWindows = BuildInfoPaths.Base + "/Win32/zipinfo.exe";
        public string ZipinfoPathMacOS = "zipinfo";

        public string ZipinfoPath
        {
            get
            {
                switch ( Environment.OSVersion.Platform )
                {
                    case PlatformID.MacOSX:
                    case PlatformID.Unix:
                        return ZipinfoPathMacOS;
                    default:
                        return ZipinfoPathWindows;
                }
            }
        }

        [Header("Restore legacy \"Total\" column (size of an asset + size of all dependencies)")]
        public bool showTotalSizeColumn;

        [Header("Enabling this slows things down a lot, but helps with troubleshooting.")]
        public bool debugLogEnabled;

        private static ColorGenerator s_defaultColorGenerator = new ColorGenerator();

        /// <summary>
        /// These values are defaults, feel free to modify them.
        /// </summary>
        [Header("Categories")]
        public Category[] categories =
        {
            new Category()
            {
                name = "Unity Built-in",
                filters = new [] { "Resources/unity_builtin_extra", "Library/unity default resources", "Resources/unity default resources" },
            },
            new Category()
            {
                name = "Texture",
                filters = new [] { "*.png", "*.tga", "*.bmp", "*.tif", "*.tiff", "*.psd", "*.jpg" },
            },
            new Category()
            {
                name = "Cubemap",
                filters = new [] { "*.cubemap" },
            },
            new Category()
            {
                name = "Lightmap",
                filters = new [] { "*Lightmap-*.exr" },
            },
            new Category()
            {
                name = "Reflection Probes",
                filters = new [] { "*ReflectionProbe-*.exr" },
            },
            new Category()
            {
                name = "Scene",
                filters = new [] { "*.unity" }
            },
            new Category()
            {
                name = "Prefab",
                filters = new [] { "*.prefab" }
            },
            new Category()
            {
                name = "Material",
                filters = new [] { "*.mat" }
            },
            new Category()
            {
                name = "Shader",
                filters = new [] { "*.shader" }
            },
            new Category()
            {
                name = "Code",
                filters = new [] { "*.dll", "*.cs", "*.js" },
            },
            new Category()
            {
                name = "Sound",
                filters = new [] { "*.wav", "*.mp3", "*.ogg" },
            },
            new Category()
            {
                name = "Binary Assets",
                filters = new [] { "*.bytes" },
            },
            new Category()
            {
                name = "Models",
                filters = new [] { "*.fbx", "*.obj" },
            },
            new Category()
            {
                name = "Animations",
                filters = new [] { "*.anim", "*.controller" },
            },
            new Category()
            {
                name = "Text Assets",
                filters = new [] { "*.xml", "*.txt" },
            },
            new Category()
            {
                name = "Sprite Atlases",
                filters = new [] { "Sprite Atlas*", "*.spriteatlas" },
            },
            new Category()
            {
                name = "Misc Assets",
                filters = new [] { "*.asset" },
            },
        };

        [Serializable]
        public class Category
        {
            public string name = string.Empty;
            public Color color = s_defaultColorGenerator.GetNextPastelColor();
            public string[] filters = { };
        }



        public string GetOutputPath(DateTime time, BuildTarget target, string buildPath)
        {
            var fullPath = outputPath;

            fullPath = fullPath.Replace(DateKey, time.ToString("yyyy-MM-dd"));
            fullPath = fullPath.Replace(TimeKey, time.ToString("HH-mm-ss"));
            fullPath = fullPath.Replace(BuildTargetKey, target.ToString());
            fullPath = fullPath.Replace(BuildDirKey, ReliablePath.GetDirectoryName(buildPath));

            fullPath = ReplaceKeySafe(fullPath, SvnRevisionKey, VersionControlUtils.GetSVNRevision, "svn revision");
            fullPath = ReplaceKeySafe(fullPath, GitShortHashKey, VersionControlUtils.GetGitShortCommitHash, "git commit short hash");
            fullPath = ReplaceKeySafe(fullPath, GitHashKey, VersionControlUtils.GetGitCommitHash, "git commit hash");
            
            var expandedResult = Environment.ExpandEnvironmentVariables(fullPath);

            return expandedResult;
        }

        [ContextMenu("Randomize Categories' Colors")]
        public void RegenerateColors()
        {
            s_defaultColorGenerator = new ColorGenerator(Guid.NewGuid().GetHashCode());
            foreach (var category in categories)
            {
                category.color = s_defaultColorGenerator.GetNextPastelColor();
            }
        }

        [ContextMenu("Randomize Categories' Colors (default)")]
        public void RegenerateColorsDefault()
        {
            s_defaultColorGenerator = new ColorGenerator();
            foreach (var category in categories)
            {
                category.color = s_defaultColorGenerator.GetNextPastelColor();
            }
        }

        public void AddRecent(string filePath)
        {
            const int MaxRecentReports = 20;
            RecentReports = Enumerable.Repeat(filePath, 1).Concat(RecentReports.Where(x => x != filePath)).Take(MaxRecentReports).ToArray();
        }

        private string ReplaceKeySafe(string path, string key, Func<string> getReplacement, string errorDesc)
        {
            if (!path.Contains(key))
                return path;

            try
            {
                var replacement = getReplacement();
                return path.Replace(key, replacement);
            }
            catch (System.Exception ex)
            {
                Log.Warning("BetterBuildInfo: Unable to obtain {1}, error: {0}", ex, errorDesc);
                return path;
            }
        }

#region Legacy

        [HideInInspector, SerializeField, Obsolete]
        private string[] recentReports = new string[0];

#endregion
    }

    /// <summary>
    /// We need this if we want unity to serialize stuff properly (file name has to match).
    /// </summary>
    public class BBI_Settings : BuildInfoSettings
    {
        private static BBI_Settings s_instance;
        private static bool s_instanceIsAnAsset;

        private static BBI_Settings FindInstance()
        {
            BBI_Settings result;

            AssetHelper.LoadAsset(out result, BuildInfoPaths.Settings);

            if (!result)
            {
                AssetHelper.LoadAsset(out result, BuildInfoPaths.LegacySettings);
            }

            if (!result)
            {
                result = AssetHelper.FindAssetsOfType<BBI_Settings>().FirstOrDefault();
            }

            return result;
        }

        internal static BBI_Settings GetInstance(bool ensureAssetGetsCreated)
        {
            if ( !s_instance )
            {
                s_instance = FindInstance();
                if ( s_instance )
                {
                    s_instanceIsAnAsset = true;
                }
                else
                {
                    s_instanceIsAnAsset = false;
                    s_instance = ScriptableObject.CreateInstance<BBI_Settings>();
                }
            }

            if ( ensureAssetGetsCreated )
            {
                if ( !s_instanceIsAnAsset )
                {
                    if (!System.IO.Directory.Exists(BuildInfoPaths.Base))
                    {
                        System.IO.Directory.CreateDirectory(BuildInfoPaths.Base);
                        AssetDatabase.Refresh();
                    }

                    AssetDatabase.CreateAsset(s_instance, BuildInfoPaths.Settings);
                    AssetDatabase.SaveAssets();
                    s_instanceIsAnAsset = true;
                }
            }

            return s_instance;
        }
    }
}
