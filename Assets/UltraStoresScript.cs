using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System.Linq;
using KModkit;

public class UltraStoresScript : MonoBehaviour {

    public KMAudio Audio;
    public KMBombInfo bomb;
    public GameObject cube;
    public GameObject[] ufos;
    public Renderer[] uforends;
    public List<KMSelectable> buttons;
    public Material[] ufocols;
    public Renderer[] brends;
    public Material[] buttoncols;
    public Material[] unlitcols;
    public TextMesh disp;

    private int[][][] rotmatrices = new int[20][][]
    {
        new int[5][] {new int[5] { 0, -1,  0,  0,  0 },
                      new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 0,  0,  0,  0,  1 } },

        new int[5][] {new int[5] { 0,  0, -1,  0,  0 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 0,  0,  0,  0,  1 } },

        new int[5][] {new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  0, -1,  0,  0 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 0,  0,  0,  0,  1 } },

        new int[5][] {new int[5] { 0,  0,  0, -1,  0 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  0,  1 } },

        new int[5][] {new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  0,  0, -1,  0 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  0,  1 } },

        new int[5][] {new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] { 0,  0,  0, -1,  0 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 0,  0,  0,  0,  1 } },

        new int[5][] {new int[5] { 0,  0,  0,  0, -1 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 1,  0,  0,  0,  0 } },

        new int[5][] {new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  0, -1 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 0,  1,  0,  0,  0 } },

        new int[5][] {new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  0, -1 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 0,  0,  1,  0,  0 } },

        new int[5][] {new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 0,  0,  0,  0, -1 },
                      new int[5] { 0,  0,  0,  1,  0 }, },

        new int[5][] {new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] {-1,  0,  0,  0,  0 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 0,  0,  0,  0,  1 } },

        new int[5][] {new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] {-1,  0,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 0,  0,  0,  0,  1 } },

        new int[5][] {new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 0, -1,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 0,  0,  0,  0,  1 } },

        new int[5][] {new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] {-1,  0,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  0,  1 } },

        new int[5][] {new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 0, -1,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  0,  1 } },

        new int[5][] {new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 0,  0, -1,  0,  0 },
                      new int[5] { 0,  0,  0,  0,  1 } },

        new int[5][] {new int[5] { 0,  0,  0,  0,  1 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] {-1,  0,  0,  0,  0 } },

        new int[5][] {new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  0,  1 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 0, -1,  0,  0,  0 } },

        new int[5][] {new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] { 0,  0,  0,  0,  1 },
                      new int[5] { 0,  0,  0,  1,  0 },
                      new int[5] { 0,  0, -1,  0,  0 } },

        new int[5][] {new int[5] { 1,  0,  0,  0,  0 },
                      new int[5] { 0,  1,  0,  0,  0 },
                      new int[5] { 0,  0,  1,  0,  0 },
                      new int[5] { 0,  0,  0,  0,  1 },
                      new int[5] { 0,  0,  0, -1,  0 }, },};
    private List<string>[][] rotations = new List<string>[2][] {new List<string>[1] { new List<string>{ "XY", "XZ", "YZ", "XW", "YW", "ZW", "XV", "YV", "ZV", "WV", "YX", "ZX", "ZY", "WX", "WY", "WZ", "VX", "VY", "VZ", "VW" } },
                                                        new List<string>[20] { new List<string> { "(XY, XZ)", "(XY, YZ)", "(XY, XW)", "(XY, YW)", "(XY, ZW)", "(XY, XV)", "(XY, YV)", "(XY, ZV)", "(XY, WV)", "(XY, ZX)", "(XY, ZY)", "(XY, WX)", "(XY, WY)", "(XY, WZ)", "(XY, VX)", "(XY, VY)", "(XY, VZ)", "(XY, VW)"},
                                                                         new List<string> { "(XZ, XY)", "(XZ, YZ)", "(XZ, XW)", "(XZ, YW)", "(XZ, ZW)", "(XZ, XV)", "(XZ, YV)", "(XZ, ZV)", "(XZ, WV)", "(XZ, YX)", "(XZ, ZY)", "(XZ, WX)", "(XZ, WY)", "(XZ, WZ)", "(XZ, VX)", "(XZ, VY)", "(XZ, VZ)", "(XZ, VW)"},
                                                                         new List<string> { "(YZ, XY)", "(YZ, XZ)", "(YZ, XW)", "(YZ, YW)", "(YZ, ZW)", "(YZ, XV)", "(YZ, YV)", "(YZ, ZV)", "(YZ, WV)", "(YZ, YX)", "(YZ, ZX)", "(YZ, WX)", "(YZ, WY)", "(YZ, WZ)", "(YZ, VX)", "(YZ, VY)", "(YZ, VZ)", "(YZ, VW)"},
                                                                         new List<string> { "(XW, XY)", "(XW, XZ)", "(XW, YZ)", "(XW, YW)", "(XW, ZW)", "(XW, XV)", "(XW, YV)", "(XW, ZV)", "(XW, WV)", "(XW, YX)", "(XW, ZX)", "(XW, ZY)", "(XW, WY)", "(XW, WZ)", "(XW, VX)", "(XW, VY)", "(XW, VZ)", "(XW, VW)"},
                                                                         new List<string> { "(YW, XY)", "(YW, XZ)", "(YW, YZ)", "(YW, XW)", "(YW, ZW)", "(YW, XV)", "(YW, YV)", "(YW, ZV)", "(YW, WV)", "(YW, YX)", "(YW, ZX)", "(YW, ZY)", "(YW, WX)", "(YW, WZ)", "(YW, VX)", "(YW, VY)", "(YW, VZ)", "(YW, VW)"},
                                                                         new List<string> { "(ZW, XY)", "(ZW, XZ)", "(ZW, YZ)", "(ZW, XW)", "(ZW, YW)", "(ZW, XV)", "(ZW, YV)", "(ZW, ZV)", "(ZW, WV)", "(ZW, YX)", "(ZW, ZX)", "(ZW, ZY)", "(ZW, WX)", "(ZW, WY)", "(ZW, VX)", "(ZW, VY)", "(ZW, VZ)", "(ZW, VW)"},
                                                                         new List<string> { "(XV, XY)", "(XV, XZ)", "(XV, YZ)", "(XV, XW)", "(XV, YW)", "(XV, ZW)", "(XV, YV)", "(XV, ZV)", "(XV, WV)", "(XV, YX)", "(XV, ZX)", "(XV, ZY)", "(XV, WX)", "(XV, WY)", "(XV, WZ)", "(XV, VY)", "(XV, VZ)", "(XV, VW)"},
                                                                         new List<string> { "(YV, XY)", "(YV, XZ)", "(YV, YZ)", "(YV, XW)", "(YV, YW)", "(YV, ZW)", "(YV, XV)", "(YV, ZV)", "(YV, WV)", "(YV, YX)", "(YV, ZX)", "(YV, ZY)", "(YV, WX)", "(YV, WY)", "(YV, WZ)", "(YV, VX)", "(YV, VZ)", "(YV, VW)"},
                                                                         new List<string> { "(ZV, XY)", "(ZV, XZ)", "(ZV, YZ)", "(ZV, XW)", "(ZV, YW)", "(ZV, ZW)", "(ZV, XV)", "(ZV, YV)", "(ZV, WV)", "(ZV, YX)", "(ZV, ZX)", "(ZV, ZY)", "(ZV, WX)", "(ZV, WY)", "(ZV, WZ)", "(ZV, VX)", "(ZV, VY)", "(ZV, VW)"},
                                                                         new List<string> { "(WV, XY)", "(WV, XZ)", "(WV, YZ)", "(WV, XW)", "(WV, YW)", "(WV, ZW)", "(WV, XV)", "(WV, YV)", "(WV, ZV)", "(WV, YX)", "(WV, ZX)", "(WV, ZY)", "(WV, WX)", "(WV, WY)", "(WV, WZ)", "(WV, VX)", "(WV, VY)", "(WV, VZ)"},

                                                                         new List<string> { "(YX, XZ)", "(YX, YZ)", "(YX, XW)", "(YX, YW)", "(YX, ZW)", "(YX, XV)", "(YX, YV)", "(YX, ZV)", "(YX, WV)", "(YX, ZX)", "(YX, ZY)", "(YX, WX)", "(YX, WY)", "(YX, WZ)", "(YX, VX)", "(YX, VY)", "(YX, VZ)", "(YX, VW)"},
                                                                         new List<string> { "(ZX, XY)", "(ZX, YZ)", "(ZX, XW)", "(ZX, YW)", "(ZX, ZW)", "(ZX, XV)", "(ZX, YV)", "(ZX, ZV)", "(ZX, WV)", "(ZX, YX)", "(ZX, ZY)", "(ZX, WX)", "(ZX, WY)", "(ZX, WZ)", "(ZX, VX)", "(ZX, VY)", "(ZX, VZ)", "(ZX, VW)"},
                                                                         new List<string> { "(ZY, XY)", "(ZY, XZ)", "(ZY, XW)", "(ZY, YW)", "(ZY, ZW)", "(ZY, XV)", "(ZY, YV)", "(ZY, ZV)", "(ZY, WV)", "(ZY, YX)", "(ZY, ZX)", "(ZY, WX)", "(ZY, WY)", "(ZY, WZ)", "(ZY, VX)", "(ZY, VY)", "(ZY, VZ)", "(ZY, VW)"},
                                                                         new List<string> { "(WX, XY)", "(WX, XZ)", "(WX, YZ)", "(WX, YW)", "(WX, ZW)", "(WX, XV)", "(WX, YV)", "(WX, ZV)", "(WX, WV)", "(WX, YX)", "(WX, ZX)", "(WX, ZY)", "(WX, WY)", "(WX, WZ)", "(WX, VX)", "(WX, VY)", "(WX, VZ)", "(WX, VW)"},
                                                                         new List<string> { "(WY, XY)", "(WY, XZ)", "(WY, YZ)", "(WY, XW)", "(WY, ZW)", "(WY, XV)", "(WY, YV)", "(WY, ZV)", "(WY, WV)", "(WY, YX)", "(WY, ZX)", "(WY, ZY)", "(WY, WX)", "(WY, WZ)", "(WY, VX)", "(WY, VY)", "(WY, VZ)", "(WY, VW)"},
                                                                         new List<string> { "(WZ, XY)", "(WZ, XZ)", "(WZ, YZ)", "(WZ, XW)", "(WZ, YW)", "(WZ, XV)", "(WZ, YV)", "(WZ, ZV)", "(WZ, WV)", "(WZ, YX)", "(WZ, ZX)", "(WZ, ZY)", "(WZ, WX)", "(WZ, WY)", "(WZ, VX)", "(WZ, VY)", "(WZ, VZ)", "(WZ, VW)"},
                                                                         new List<string> { "(VX, XY)", "(VX, XZ)", "(VX, YZ)", "(VX, XW)", "(VX, YW)", "(VX, ZW)", "(VX, YV)", "(VX, ZV)", "(VX, WV)", "(VX, YX)", "(VX, ZX)", "(VX, ZY)", "(VX, WX)", "(VX, WY)", "(VX, WZ)", "(VX, VY)", "(VX, VZ)", "(VX, VW)"},
                                                                         new List<string> { "(VY, XY)", "(VY, XZ)", "(VY, YZ)", "(VY, XW)", "(VY, YW)", "(VY, ZW)", "(VY, XV)", "(VY, ZV)", "(VY, WV)", "(VY, YX)", "(VY, ZX)", "(VY, ZY)", "(VY, WX)", "(VY, WY)", "(VY, WZ)", "(VY, VX)", "(VY, VZ)", "(VY, VW)"},
                                                                         new List<string> { "(VZ, XY)", "(VZ, XZ)", "(VZ, YZ)", "(VZ, XW)", "(VZ, YW)", "(VZ, ZW)", "(VZ, XV)", "(VZ, YV)", "(VZ, WV)", "(VZ, YX)", "(VZ, ZX)", "(VZ, ZY)", "(VZ, WX)", "(VZ, WY)", "(VZ, WZ)", "(VZ, VX)", "(VZ, VY)", "(VZ, VW)"},
                                                                         new List<string> { "(VW, XY)", "(VW, XZ)", "(VW, YZ)", "(VW, XW)", "(VW, YW)", "(VW, ZW)", "(VW, XV)", "(VW, YV)", "(VW, ZV)", "(VW, YX)", "(VW, ZX)", "(VW, ZY)", "(VW, WX)", "(VW, WY)", "(VW, WZ)", "(VW, VX)", "(VW, VY)", "(VW, VZ)"},} };
    private int[][] gen = new int[32][];
    private int[][] oldpos = new int[32][] { new int[5] { -1, -1, -1, -1, -1 }, new int[5] { 1, -1, -1, -1, -1 }, new int[5] { -1, 1, -1, -1, -1 }, new int[5] { -1, -1, 1, -1, -1 }, new int[5] { -1, -1, -1, 1, -1 }, new int[5] { -1, -1, -1, -1, 1 }, new int[5] { 1, 1, -1, -1, -1 }, new int[5] { 1, -1, 1, -1, -1 }, new int[5] { 1, -1, -1, 1, -1 }, new int[5] { 1, -1, -1, -1, 1 }, new int[5] { -1, 1, 1, -1, -1 }, new int[5] { -1, 1, -1, 1, -1 }, new int[5] { -1, 1, -1, -1, 1 }, new int[5] { -1, -1, 1, 1, -1 }, new int[5] { -1, -1, 1, -1, 1 }, new int[5] { -1, -1, -1, 1, 1 }, new int[5] { 1, 1, 1, -1, -1 }, new int[5] { 1, 1, -1, 1, -1 }, new int[5] { 1, 1, -1, -1, 1 }, new int[5] { 1, -1, 1, 1, -1 }, new int[5] { 1, -1, 1, -1, 1 }, new int[5] { 1, -1, -1, 1, 1 }, new int[5] { -1, 1, 1, 1, -1 }, new int[5] { -1, 1, 1, -1, 1 }, new int[5] { -1, 1, -1, 1, 1 }, new int[5] { -1, -1, 1, 1, 1 }, new int[5] { 1, 1, 1, 1, -1 }, new int[5] { 1, 1, 1, -1, 1 }, new int[5] { 1, 1, -1, 1, 1 }, new int[5] { 1, -1, 1, 1, 1 }, new int[5] { -1, 1, 1, 1, 1 }, new int[5] { 1, 1, 1, 1, 1 } };
    private int[][] newpos = new int[32][] { new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5], new int[5] };
    private int[][] vals = new int[3][] { new int[5], new int[5], new int[6] };
    private int D;
    private List<int[][]> matrixlist = new List<int[][]> { };
    private List<string> rotlist = new List<string> { };
    private List<string> cycle = new List<string> { };
    private List<string> order = new List<string> { };
    private string[][] sigdigits = new string[3][] { new string[6] { "R", "G", "B", "C", "M", "Y" }, new string[6] { "Y", "B", "M", "G", "R", "C" }, new string[6] { "M", "C", "R", "Y", "G", "B" } };
    private string[] balter = new string[6];
    private string[] answer = new string[2];
    private bool subwaiting;
    private bool submissable;
    private bool[] alreadypressed = new bool[8];
    private bool neginput;
    private int stage;
    private string[] funcseq = new string[5];
    private string[] funccatch = new string[4];
    private int sound;

    private static int moduleIDCounter;
    private int moduleID;
    private bool moduleSolved;

    private void Awake()
    {
        moduleID = moduleIDCounter++;
        foreach(Renderer ufo in uforends)
        {
            ufo.material.color = new Color32(0, 0, 0, 255);
        }
        foreach (Renderer brend in brends)
        {
            brend.material = buttoncols[8];
        }
        foreach(KMSelectable button in buttons)
        {
            int b = buttons.IndexOf(button);
            button.OnInteract += delegate () { ButtonPress(b); return false; };
            button.OnHighlight += delegate () { ButtonHL(b);};
            button.OnHighlightEnded += delegate () { ButtonHLOff(); };
        }     
    }

    void Start()
    {
        StartCoroutine(StartCube());
        if (moduleID == 0)
        {
            Audio.PlaySoundAtTransform("Klaxon", transform);
        }
        for (int i = 0; i < 3; i++)
        {
            vals[i][0] = ("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(bomb.GetSerialNumber()[(2 * i + 2) % 6]) * 36 + "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(bomb.GetSerialNumber()[(2 * i + 3) % 6])) % 365;
        }
        for (int i = 0; i < 6; i++)
        {
            D += "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(bomb.GetSerialNumber()[i]);
        }
        Debug.LogFormat("[UltraStores #{0}]D = {2} + {3} + {4} + {5} + {6} + {7} = {1}", moduleID, D, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(bomb.GetSerialNumber()[0]), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(bomb.GetSerialNumber()[1]), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(bomb.GetSerialNumber()[2]), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(bomb.GetSerialNumber()[3]), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(bomb.GetSerialNumber()[4]), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(bomb.GetSerialNumber()[5]));
        Generate();
    }

    private void ButtonHL(int b)
    {
        if(submissable == true && subwaiting == false && b < 8)
        {
            disp.text = cycle[b];
        }
    }

    private void ButtonHLOff()
    {
        disp.text = string.Empty;
    }
	
    private void ButtonPress(int b)
    {
        if (moduleSolved == false && subwaiting == false)
        {
            buttons[b].AddInteractionPunch();
            if (b == 8)
            {
                Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
                if (submissable == false)
                {
                    submissable = true;
                    subwaiting = true;
                }
                else
                {
                    submissable = false;
                    subwaiting = true;
                    for(int i = 0; i < 8; i++)
                    {
                        alreadypressed[i] = false;
                    }
                    Audio.PlaySoundAtTransform("InputCheck", transform);
                    sound = 0;
                    StartCoroutine(Submit());
                }
            }
            else if (submissable == true)
            {
                if (cycle[b] == "W")
                {
                    Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonRelease, transform);
                    neginput = false;
                    brends[b].material = unlitcols[0];
                    brends[cycle.IndexOf("K")].material = buttoncols[7];
                }
                else if (cycle[b] == "K")
                {
                    Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonRelease, transform);
                    neginput = true;
                    brends[b].material = unlitcols[7];
                    brends[cycle.IndexOf("W")].material = buttoncols[0];
                }
                else
                {
                    if (alreadypressed[b] == false)
                    {
                        sound++;
                        Audio.PlaySoundAtTransform("Upress" + sound.ToString(), transform);
                        alreadypressed[b] = true;
                        if (neginput == true)
                        {
                            answer[1] += "-" + cycle[b];
                            brends[b].material = unlitcols["#RGBCMY".IndexOf(cycle[b])];
                        }
                        else
                        {
                            answer[1] += "+" + cycle[b];
                            brends[b].material = unlitcols["#RGBCMY".IndexOf(cycle[b])];
                        }
                    }
                }
            }
        }
    }

    private void Generate()
    {
        matrixlist.Clear();
        rotlist.Clear();
        List<int> selector = new List<int> { 0, 0, 0, 0, 1 };
        for(int i = 0; i < stage + 3; i++)
        {
            int r = Random.Range(0, selector.Count);
            int s = selector[r];
            selector.RemoveAt(r);
            if(s == 0)
            {
                int g = Random.Range(0, 20);
                rotlist.Add(rotations[0][0][g]);
                matrixlist.Add(rotmatrices[g]);
                vals[stage][i + 1] = SingRot(vals[stage][i], i, stage, g);
            }
            else
            {
                int[] g = new int[2] { Random.Range(0, 20), Random.Range(0, 18) };
                string pair = rotations[1][g[0]][g[1]];
                rotlist.Add(pair);
                string[] indrot = new string[2] { string.Join(string.Empty, new string[2] {pair[1].ToString(), pair[2].ToString()}), string.Join(string.Empty, new string[2] { pair[5].ToString(), pair[6].ToString() } )};
                Debug.Log("(" + indrot[0] + ", " + indrot[1] + ")");
                int[][][] mat = new int[2][][] { rotmatrices[rotations[0][0].IndexOf(indrot[0])], rotmatrices[rotations[0][0].IndexOf(indrot[1])] };
                MatrixMultiply(mat[0], mat[1]);
                int[] rs = new int[3] { rotations[0][0].IndexOf(indrot[0]), rotations[0][0].IndexOf(indrot[1]), 0 };
                for(int j = 0; j < 6; j++)
                {
                    if (j < 5)
                    {
                        if (indrot[0].Contains("XYZWV"[j]) && indrot[1].Contains("XYZWV"[j]))
                        {
                            rs[2] = j;
                            break;
                        }
                    }
                    else
                    {
                        List<char> reductor = new List<char> { 'X', 'Y', 'Z', 'W', 'V'};
                        for (int k = 0; k < pair.Length; k++)
                        {
                            if (reductor.Contains(pair[k]))
                            {
                                reductor.Remove(pair[k]);
                            }
                        }
                        rs[2] = "XYZWV".IndexOf(reductor[0].ToString());
                    }
                }
                vals[stage][i + 1] = DualRot(vals[stage][i], i, stage, rs);
            }
        }
        Debug.LogFormat("[UltraStores #{0}]The rotations for stage {1} are: {2}", moduleID, stage, string.Join(" - ", rotlist.ToArray()));
        Debug.LogFormat("[UltraStores #{0}]{1}0 = {3}*36 + {4} = {5} ≈ {2}", moduleID, "abc"[stage], vals[stage][0], "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(bomb.GetSerialNumber()[(stage * 2 + 2) % 6]), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(bomb.GetSerialNumber()[(stage * 2 + 3) % 6]), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(bomb.GetSerialNumber()[(stage * 2 + 2) % 6]) * 36 + "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(bomb.GetSerialNumber()[(stage * 2 + 3) % 6]));
        for (int i = 1; i < stage + 4; i++)
        {
            Debug.LogFormat("[UltraStores #{0}]{1}{2} = {3}", moduleID, "abc"[stage] , i, funcseq[i - 1]);
        }
        int x = vals[stage][stage + 3];
        neginput = false;
        for (int i = 6; i > 0; i--)
        {
            if (Mathf.Abs(x) < ((int)Mathf.Pow(3, i - 1) + 1) / 2)
            {
                balter[6 - i] = "0";
            }
            else
            {
                if (x > 0)
                {
                    balter[6 - i] = "+";
                    x -= (int)Mathf.Pow(3, i - 1);
                }
                else
                {
                    balter[6 - i] = "-";
                    x += (int)Mathf.Pow(3, i - 1);
                }
            }
        }
        Debug.LogFormat("[UltraStores #{0}]{1} in balanced ternary is {2}", moduleID, vals[stage][stage + 3], string.Join(string.Empty, balter));
    }

    private void MatrixMultiply(int[][] a, int[][] b)
    {
        int[][] prod = new int[5][] { new int[5], new int[5], new int[5], new int[5], new int[5]};
        string[][] prodl = new string[5][] { new string[5], new string[5], new string[5], new string[5], new string[5] };
        string[] prodlo = new string[5];
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                int n = 0;
                for(int k = 0; k < 5; k++)
                {
                    n += a[i][k] * b[k][j];
                }
                prod[i][j] = n;
                prodl[i][j] = n.ToString();
            }
            prodlo[i] = string.Join(" ", prodl[i]);
        }
        Debug.Log(string.Join("\n", prodlo));
        matrixlist.Add(prod);
    }

    private void VectorMultiply(int[][] a, int[] b, int c)
    {
        int[] prod = new int[5];
        string[] bl = new string[5];
        string[] prodl = new string[5];
        for (int i = 0; i < 5; i++)
        {
            int n = 0;
            bl[i] = b[i].ToString();
            for (int j = 0; j < 5; j++)
            {
                n += a[i][j] * b[j];               
            }
            prod[i] = n;
            prodl[i] = n.ToString();
        }
        newpos[c] = prod;
    }

    private int SingRot(int x, int i, int j, int k)
    {
        int v = x;
        switch (k)
        {
            case 0:
                switch (j)
                {
                    case 0:
                        x += D;
                        funcseq[i] = "XY(" + v + ") = " + v + " + " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += vals[0][i];
                        funcseq[i] = "XY(" + v + ") = " + v + " + " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x += vals[1][i] - vals[0][i];
                        funcseq[i] = "XY(" + v + ") = " + v + " + " + vals[1][i] + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 1:
                switch (j)
                {
                    case 0:
                        x = x * 2 - D;
                        funcseq[i] = "XZ(" + v + ") = " + v + "*2" + " - " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = x * 2 - vals[0][i];
                        funcseq[i] = "XZ(" + v + ") = " + v + "*2" + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = x * 2 - vals[1][i] - vals[0][i];
                        funcseq[i] = "XZ(" + v + ") = " + v + "*2" + " - " + vals[1][i] + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 2:
                switch (j)
                {
                    case 0:
                        x += 2 * D;
                        funcseq[i] = "YZ(" + v + ") = " + v + " + " + D + "*2" + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += 2 * vals[0][i];
                        funcseq[i] = "YZ(" + v + ") = " + v + " + " + vals[0][i] + "*2" + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x += 2 * vals[1][i] - vals[0][i];
                        funcseq[i] = "YZ(" + v + ") = " + v + " + " + vals[1][i] + "*2" + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 3:
                switch (j)
                {
                    case 0:
                        x = 2 * D - x;
                        funcseq[i] = "XW(" + v + ") = " + D + "*2" + " - " + v + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = 3 * D - x - vals[0][i];
                        funcseq[i] = "XW(" + v + ") = " + D + "*3" + " - " + v + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = 4 * D - x - vals[1][i] - vals[0][i];
                        funcseq[i] = "XW(" + v + ") = " + D + "*4" + " - " + v + " - " + vals[1][i] + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 4:
                switch (j)
                {
                    case 0:
                        x = 2 * x + D - 35 * (i + 1);
                        funcseq[i] = "YW(" + v + ") = " + v + "*2" + " + " + D + " - 35*" + (i + 1) + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = 2 * x + Mathf.Abs(vals[0][i]) - 12 * (int)Mathf.Pow(i + 1, 2);
                        funcseq[i] = "YW(" + v + ") = " + v + "*2" + " + |" + vals[0][i] + "| - 12*(" + (i + 1) + "^2) = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = 2 * x + Mathf.Abs(vals[1][i]) + Mathf.Abs(vals[0][i]) - 5 * (int)Mathf.Pow(i + 1, 3);
                        funcseq[i] = "YW(" + v + ") = " + v + "*2" + " + |" + vals[1][i] + "| + |" + vals[0][i] + "| - 5*(" + (i + 1) + "^3) = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 5:
                switch (j)
                {
                    case 0:
                        x += (int)Mathf.Pow((x + 600) % 6, 3);
                        funcseq[i] = "ZW(" + v + ") = " + v + " + " + (v + 600) % 6 + "^3 = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += (int)Mathf.Pow((vals[0][i] + 700) % 7, 3);
                        funcseq[i] = "ZW(" + v + ") = " + v + " + " + (vals[0][i] + 700) % 7 + "^3 = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x += (int)Mathf.Pow((vals[1][i] + 600) % 6, 3) + (int)Mathf.Pow((vals[0][i] + 600) % 6, 3);
                        funcseq[i] = "ZW(" + v + ") = " + v + " + " + (vals[1][i] + 600) % 6 + "^3 + " + (vals[0][i] + 600) % 6 + "^3 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 6:
                switch (j)
                {
                    case 0:
                        x = 2 * (D - x);
                        funcseq[i] = "XV(" + v + ") = " + "( " + D + " - " + v + " )*2 = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = 2 * x - 3 * (D - vals[0][i]);
                        funcseq[i] = "XV(" + v + ") = " + v + "*2 - " + "( " + D + " - " + vals[0][i] + " )*3 = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = 2 * x - 4 * (D - vals[1][i]);
                        funcseq[i] = "XV(" + v + ") = " + v + "*2 - " + "( " + D + " - " + vals[1][i] + " )*4 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 7:
                switch (j)
                {
                    case 0:
                        x += (int)Mathf.Pow(D % 6, 3) - 35 * (i + 1);
                        funcseq[i] = "YV(" + v + ") = " + v + " + " + (D % 6) + "^3 - 35*" + (i + 1) + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += (int)Mathf.Pow((vals[0][i] + 700) % 7, 3) - 12 * (int)Mathf.Pow(i + 1, 2);
                        funcseq[i] = "YV(" + v + ") = " + v + " + " + (vals[0][i] + 700) % 6 + "^3 - 12*(" + (i + 1) + "^2) = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x += (int)Mathf.Pow((vals[1][i] + 800) % 8, 3) - 5 * (int)Mathf.Pow(i + 1, 3);
                        funcseq[i] = "YV(" + v + ") = " + v + " + " + (vals[1][i] + 800) % 8 + "^3 - 5*(" + (i + 1) + "^3) = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 8:
                switch (j)
                {
                    case 0:
                        x = D + Mathf.FloorToInt(x / 2);
                        funcseq[i] = "ZV(" + v + ") = " + Mathf.FloorToInt(v / 2) + " + " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += Mathf.FloorToInt(x / 2) - vals[0][i];
                        funcseq[i] = "ZV(" + v + ") = " + v + " + " + Mathf.FloorToInt(v / 2) + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = 2 * vals[1][i] + Mathf.FloorToInt(x / (i + 1));
                        funcseq[i] = "ZV(" + v + ") = " + Mathf.FloorToInt(v / (i + 1)) + " + " + vals[1][i] + "*2 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 9:
                switch (j)
                {
                    case 0:
                        x = 5 * x - 3 * D;
                        funcseq[i] = "WV(" + v + ") = " + v + "*5 - " + D + "*3 = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = 8 * x - 5 * D + 3 * vals[0][i];
                        funcseq[i] = "WV(" + v + ") = " + v + "*8 - " + D + "*5 + " + vals[0][i] + "*3 = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = 13 * x - 8 * D + 5 * vals[0][1] - 3 * vals[1][i];
                        funcseq[i] = "WV(" + v + ") = " + v + "*13 - " + D + "*8 + " + vals[0][i] + "*5 - " + vals[1][i] + "*3 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 10:
                switch (j)
                {
                    case 0:
                        x -= D;
                        funcseq[i] = "YX(" + v + ") = " + v + " - " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x -= vals[0][i];
                        funcseq[i] = "YX(" + v + ") = " + v + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x += vals[0][i] - vals[1][i];
                        funcseq[i] = "YX(" + v + ") = " + v + " + " + vals[0][i] + " - " + vals[1][i] + " = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 11:
                switch (j)
                {
                    case 0:
                        x = x * 2 + D;
                        funcseq[i] = "ZX(" + v + ") = " + v + "*2" + " + " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = x * 2 - vals[0][i];
                        funcseq[i] = "ZX(" + v + ") = " + v + "*2" + " - " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = vals[1][i] + vals[0][i] - 2 * x;
                        funcseq[i] = "ZX(" + v + ") = " + vals[1][i] + " + " + vals[0][i] + " - " + v + "*2 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 12:
                switch (j)
                {
                    case 0:
                        x -= 2 * D;
                        funcseq[i] = "ZY(" + v + ") = " + v + " - " + D + "*2" + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x -= 2 * vals[0][i];
                        funcseq[i] = "ZY(" + v + ") = " + v + " - " + vals[0][i] + "*2" + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x += 2 * vals[0][i] - vals[1][i];
                        funcseq[i] = "ZY(" + v + ") = " + v + " + " + vals[0][i] + "*2 - " + vals[1][i] + " = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 13:
                switch (j)
                {
                    case 0:
                        x += 2 * D;
                        funcseq[i] = "WX(" + v + ") = " + v + " + " + D + "*2" + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += 3 * D - vals[0][i];
                        funcseq[i] = "WX(" + v + ") = " + v + " + " + D + "*3" + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x += 4 * D - vals[1][i] - vals[0][i];
                        funcseq[i] = "WX(" + v + ") = " + v + " + " + D + "*4" + " - " + vals[1][i] + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 14:
                switch (j)
                {
                    case 0:
                        x = 2 * x - D - 35 * (i + 1);
                        funcseq[i] = "WY(" + v + ") = " + v + "*2 - " + D + " - 35*" + (i + 1) + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = 2 * x - Mathf.Abs(vals[0][i]) - 12 * (int)Mathf.Pow(i + 1, 2);
                        funcseq[i] = "WY(" + v + ") = " + v + "*2" + " - |" + vals[0][i] + "| - 12*(" + (i + 1) + "^2) = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = 2 * x - Mathf.Abs(vals[1][i]) - Mathf.Abs(vals[0][i]) - 5 * (int)Mathf.Pow(i + 1, 3);
                        funcseq[i] = "WY(" + v + ") = " + v + "*2" + " - |" + vals[1][i] + "| - |" + vals[0][i] + "| - 5*(" + (i + 1) + "^3) = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 15:
                switch (j)
                {
                    case 0:
                        x -= (int)Mathf.Pow((x + 700) % 7, 3);
                        funcseq[i] = "WZ(" + v + ") = " + v + " - " + (v + 700) % 7 + "^3 = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x -= (int)Mathf.Pow((vals[0][i] + 600) % 6, 3);
                        funcseq[i] = "WZ(" + v + ") = " + v + " - " + (vals[0][i] + 600) % 6 + "^3 = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x -= (int)Mathf.Pow((vals[1][i] + 700) % 7, 3) + (int)Mathf.Pow((vals[0][i] + 700) % 7, 3);
                        funcseq[i] = "WZ(" + v + ") = " + v + " - " + (vals[1][i] + 700) % 7 + "^3 - " + (vals[0][i] + 700) % 7 + "^3 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 16:
                switch (j)
                {
                    case 0:
                        x = 2 * (D + x);
                        funcseq[i] = "VX(" + v + ") = " + "( " + D + " + " + v + " )*2 = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = 2 * x - 3 * (D + vals[0][i]);
                        funcseq[i] = "VX(" + v + ") = " + v + "*2 - " + "( " + D + " + " + vals[0][i] + " )*3 = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = 2 * x - 4 * (D + vals[1][i]);
                        funcseq[i] = "VX(" + v + ") = " + v + "*2 - " + "( " + D + " + " + vals[1][i] + " )*4 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 17:
                switch (j)
                {
                    case 0:
                        x -= (int)Mathf.Pow(D % 6, 3) + 35 * (i + 1);
                        funcseq[i] = "VY(" + v + ") = " + v + " - " + (D % 6) + "^3 - 35*" + (i + 1) + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x -= (int)Mathf.Pow((vals[0][i] + 700) % 7, 3) + 12 * (int)Mathf.Pow(i + 1, 2);
                        funcseq[i] = "VY(" + v + ") = " + v + " - " + (vals[0][i] + 700) % 6 + "^3 - 12*(" + (i + 1) + "^2) = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x -= (int)Mathf.Pow((vals[1][i] + 800) % 8, 3) + 5 * (int)Mathf.Pow(i + 1, 3);
                        funcseq[i] = "VY(" + v + ") = " + v + " - " + (vals[1][i] + 800) % 8 + "^3 - 5*(" + (i + 1) + "^3) = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 18:
                switch (j)
                {
                    case 0:
                        x = Mathf.FloorToInt(x / 2) - D;
                        funcseq[i] = "VZ(" + v + ") = " + Mathf.FloorToInt(v / 2) + " - " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += vals[0][i] + Mathf.FloorToInt(x / 2);
                        funcseq[i] = "VZ(" + v + ") = " + v + " + " + Mathf.FloorToInt(v / 2) + " + " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = Mathf.FloorToInt(x / (i + 1)) - 2 * vals[1][0];
                        funcseq[i] = "VZ(" + v + ") = " + Mathf.FloorToInt(v / (i + 1)) + " - " + vals[1][i] + "*2 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 19:
                switch (j)
                {
                    case 0:
                        x = 5 * x + 3 * D;
                        funcseq[i] = "VW(" + v + ") = " + v + "*5 + " + D + "*3 = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = 8 * x + 5 * D - 3 * vals[0][i];
                        funcseq[i] = "VW(" + v + ") = " + v + "*8 + " + D + "*5 - " + vals[0][i] + "*3 = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = 13 * x + 8 * D - 5 * vals[0][1] + 3 * vals[1][i];
                        funcseq[i] = "VW(" + v + ") = " + v + "*13 + " + D + "*8 - " + vals[0][i] + "*5 + " + vals[1][i] + "*3 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
        }
        return x % 365;
    }

    private int DualRot(int x, int i, int j, int[] k)
    {
        int v = x;
        SingRot(v, i, j, k[0]);
        funccatch[0] = funcseq[i];
        SingRot(v, i, j, k[1]);
        funccatch[1] = funcseq[i];
        switch (k[2])
        {
            case 0:
                switch (j)
                {
                    case 0:
                        x = 2 * D - Mathf.Abs(SingRot(x, i, j, k[0]) - SingRot(x, i, j, k[1]));
                        funcseq[i] = "X(" + v + ") = 2*" + D + " - |[" + SingRot(v, i, j, k[0]) + "] - [" + SingRot(v, i, j, k[1]) + "]| = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                    case 1:
                        x = 3 * D - Mathf.Abs(SingRot(x, i, j, k[0]) + SingRot(x, i, j, k[1]));
                        funcseq[i] = "X(" + v + ") = 3*" + D + " - |[" + SingRot(v, i, j, k[0]) + "] + [" + SingRot(v, i, j, k[1]) + "]| = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                    case 2:
                        x = 4 * D - Mathf.Abs(SingRot(x, i, j, k[0])) - Mathf.Abs(SingRot(x, i, j, k[1]));
                        funcseq[i] = "X(" + v + ") = 4*" + D + " - |[" + SingRot(v, i, j, k[0]) + "]| + |[" + SingRot(v, i, j, k[1]) + "]| = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                }
                break;
            case 1:
                switch (j)
                {
                    case 0:
                        x = D - SingRot(x, i, j, k[0]) - SingRot(x, i, j, k[1]);
                        funcseq[i] = "Y(" + v + ") = " + D + " - [" + SingRot(v, i, j, k[0]) + "] - [" + SingRot(v, i, j, k[1]) + "] = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                    case 1:
                        x = vals[0][i] - SingRot(x, i, j, k[0]) - SingRot(x, i, j, k[1]);
                        funcseq[i] = "Y(" + v + ") = " + vals[0][i] + " - [" + SingRot(v, i, j, k[0]) + "] - [" + SingRot(v, i, j, k[1]) + "] = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                    case 2:
                        x = vals[1][i] - SingRot(x, i, j, k[0]) - SingRot(x, i, j, k[1]);
                        funcseq[i] = "Y(" + v + ") = " + vals[1][i] + " - [" + SingRot(v, i, j, k[0]) + "] - [" + SingRot(v, i, j, k[1]) + "] = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                }
                break;
            case 2:
                switch (j)
                {
                    case 0:
                        x = SingRot(x, i, j, k[0]) + SingRot(x, i, j, k[1]) - x;
                        funcseq[i] = "Z(" + v + ") = [" + SingRot(v, i, j, k[0]) + "] + [" + SingRot(v, i, j, k[1]) + "] - " + v + " = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                    case 1:
                        x = SingRot(x, i, j, k[0]) + SingRot(x, i, j, k[1]) - x - vals[0][i];
                        funcseq[i] = "Z(" + v + ") = [" + SingRot(v, i, j, k[0]) + "] + [" + SingRot(v, i, j, k[1]) + "] - " + v + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                    case 2:
                        x = SingRot(x, i, j, k[0]) + SingRot(x, i, j, k[1]) - x - vals[1][i] - vals[0][i];
                        funcseq[i] = "Z(" + v + ") = [" + SingRot(v, i, j, k[0]) + "] + [" + SingRot(v, i, j, k[1]) + "] - " + v + " - " + vals[1][i] + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                }
                break;
            case 3:
                switch (j)
                {
                    case 0:
                        x = SingRot(x, i, j, k[0]) + SingRot(x, i, j, k[1]);
                        funcseq[i] = "W(" + v + ") = [" + SingRot(v, i, j, k[0]) + "] + [" + SingRot(v, i, j, k[1]) + "] = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                    case 1:
                        SingRot(v + vals[0][i], i, j, k[0]);
                        funccatch[0] = funcseq[i];
                        SingRot(v + vals[0][i], i, j, k[1]);
                        funccatch[1] = funcseq[i];
                        x = SingRot(x + vals[0][i], i, j, k[0]) + SingRot(x + vals[0][i], i, j, k[1]);
                        funcseq[i] = "W(" + v + ") = [" + SingRot(v + vals[0][i], i, j, k[0]) + "] + [" + SingRot(v + vals[0][i], i, j, k[1]) + "] = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                    case 2:
                        SingRot(v + vals[1][i] + vals[0][i], i, j, k[0]);
                        funccatch[0] = funcseq[i];
                        SingRot(v + vals[1][i] + vals[0][i], i, j, k[1]);
                        funccatch[1] = funcseq[i];
                        x = SingRot(x + vals[1][i] + vals[0][i], i, j, k[0]) + SingRot(x + vals[1][i] + vals[0][i], i, j, k[1]);
                        funcseq[i] = "W(" + v + ") = [" + SingRot(v + vals[1][i] + vals[0][i], i, j, k[0]) + "] + [" + SingRot(v + vals[1][i] + vals[0][i], i, j, k[1]) + "] = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                }
                break;
            case 4:
                switch (j)
                {
                    case 0:
                        SingRot(D, i, j, k[0]);
                        funccatch[0] = funcseq[i];
                        SingRot(D, i, j, k[1]);
                        funccatch[1] = funcseq[i];
                        x += Mathf.Max(SingRot(D, i, j, k[0]), SingRot(D, i, j, k[1])) - D;
                        funcseq[i] = "V(" + v + ") = " + v + " + max([" + SingRot(D , i, j, k[0]) + "], [" + SingRot(D , i, j, k[1]) + "]) - " + D + " = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                    case 1:
                        x = Mathf.Max(SingRot(x, i, j, k[0]), SingRot(x, i, j, k[1])) + vals[0][i] - D;
                        funcseq[i] = "V(" + v + ") = max([" + SingRot(v, i, j, k[0]) + "], [" + SingRot(v, i, j, k[1]) + "]) + " + vals[0][i] + " - " + D + " = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}]" + funccatch[0] + "\n[UltraStores #{" + moduleID + "}]" + funccatch[1];
                        break;
                    case 2:
                        SingRot(SingRot(v, i, j, k[1]), i, j, k[0]);
                        funccatch[2] = funcseq[i];
                        SingRot(SingRot(v, i, j, k[0]), i, j, k[1]);
                        funccatch[3] = funcseq[i];
                        x = Mathf.Max(SingRot(SingRot(x, i, j, k[1]), i, j, k[0]) + SingRot(SingRot(x, i, j, k[0]), i, j, k[1]));
                        funcseq[i] = "V(" + v + ") = max([[" + SingRot(SingRot(v, i, j, k[1]), i, j, k[0]) + "]], [[" + SingRot(SingRot(v, i, j, k[0]), i, j, k[1]) + "]]) = " + x + " ≈ " + x % 365 + "\n[UltraStores #{" + moduleID + "}][" + funccatch[0] + "]\n[UltraStores #{" + moduleID + "}]" + funccatch[3] + "\n[UltraStores #{" + moduleID + "}][" + funccatch[1] + "]\n[UltraStores #{" + moduleID + "}]" + funccatch[2];
                        break;
                }
                break;
        }
        return x % 365;
    }

    private IEnumerator StartCube()
    {
        for (int i = 0; i < 8; i++)
        {
            brends[i].material = buttoncols[8];
        }
        for (int i = 0; i < 32; i++)
        {
            if (moduleSolved == false)
            {
                gen[i] = new int[3] { Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255) };
            }
            else
            {
                gen[i] = new int[3] { 0, 255, 0 };
            }
        }
        for (int i = 0; i < 25; i++)
        {
            cube.transform.localPosition += new Vector3(0, 0, 0.1f);
            for (int j = 0; j < 32; j++)
            {
                ufos[j].transform.localPosition += new Vector3(0.2f*oldpos[j][0] + 0.05f*oldpos[j][4] + 0.15f*oldpos[j][3], 0.2f*oldpos[j][1] + 0.1f*oldpos[j][4] + 0.05f*oldpos[j][3], 0.2f*oldpos[j][2] + 0.15f*oldpos[j][4] + 0.1f*oldpos[j][3]);
                uforends[j].material.color += new Color32((byte)(gen[j][0] / 25), (byte)(gen[j][1] / 25), (byte)(gen[j][2] / 25), 0);
            }
            yield return new WaitForSeconds(0.01f);
        }
        subwaiting = false;
        for (int j = 0; j < 32; j++)
        {
            for (int k = 0; k < 5; k++)
            {
                newpos[j][k] = oldpos[j][k];
            }
        }
        if (moduleSolved == false)
        {
            yield return StartCoroutine(RotCycle());
        }
    }

    private IEnumerator RotCycle()
    {
        for (int i = 0; i < (stage + 4) * 25; i++)
        {
            if(i % 25 == 0)
            {
                for(int j = 0; j < 32; j++)
                {
                    for(int k = 0; k < 5; k++)
                    {
                        oldpos[j][k] = newpos[j][k];
                    }
                }
                if (subwaiting == true)
                {
                    subwaiting = false;
                    StopAllCoroutines();
                    StartCoroutine(StartSubmission());
                }
                else if (i < (stage + 3) * 25)
                {
                    for(int j = 0; j < 32; j++)
                    {
                        VectorMultiply(matrixlist[i / 25], oldpos[j], j);
                    }
                }
                else
                {
                    i = -1;
                    yield return new WaitForSeconds(1);
                }
            }
            else if(i < (stage + 3) * 25)
            {
                for(int j = 0; j < 32; j++)
                {
                    ufos[j].transform.localPosition += new Vector3(0.2f * (newpos[j][0] - oldpos[j][0]) + 0.05f * (newpos[j][4] - oldpos[j][4]) + 0.15f * (newpos[j][3] - oldpos[j][3]), 0.2f *(newpos[j][1] - oldpos[j][1]) + 0.1f * (newpos[j][4] - oldpos[j][4]) + 0.05f * (newpos[j][3] - oldpos[j][3]), 0.2f * (newpos[j][2] - oldpos[j][2]) + 0.15f * (newpos[j][4] - oldpos[j][4]) + 0.1f * (newpos[j][3] - oldpos[j][3]));
                }
                yield return new WaitForSeconds(0.04f);
            }
        }
    }

    private IEnumerator StartSubmission()
    {
        cycle.Clear();
        List<string> origlist = new List<string> { "W", "R", "G", "B", "C", "M", "Y", "K"};
        string temp = string.Empty;
        string[] inout = new string[2];
        order = sigdigits[stage].ToList();
        Audio.PlaySoundAtTransform("Initiate", transform);
        for (int i = 0; i < 25; i++)
        {
            cube.transform.localPosition -= new Vector3(0, 0, 0.1f);
            for (int j = 0; j < 32; j++)
            {
                ufos[j].transform.localPosition -= new Vector3(0.2f * oldpos[j][0] + 0.05f * oldpos[j][4] + 0.15f * oldpos[j][3], 0.2f * oldpos[j][1] + 0.1f * oldpos[j][4] + 0.05f * oldpos[j][3], 0.2f * oldpos[j][2] + 0.15f * oldpos[j][4] + 0.1f * oldpos[j][3]);
                uforends[j].material.color -= new Color32((byte)(gen[j][0] / 25), (byte)(gen[j][1] / 25), (byte)(gen[j][2] / 25), 0);
            }
            yield return new WaitForSeconds(0.01f);
        }
        for(int i = 0; i < 8; i++)
        {
            int r = Random.Range(0, 8 - i);
            cycle.Add(origlist[r]);
            origlist.RemoveAt(r);
            brends[i].material = buttoncols["WRGBCMYK".IndexOf(cycle[i])];
        }
        brends[cycle.IndexOf("W")].material = unlitcols[0];
        Debug.LogFormat("[UltraStores #{0}]The colours, in clockwise order, are: {1}", moduleID, string.Join(string.Empty, cycle.ToArray()));
        if (cycle.IndexOf("W") == 0)
        {
            inout[0] = string.Join(string.Empty, order.ToArray());
            for(int i = 0; i < 3; i++)
            {
                temp = order[i];
                order[i] = order[5 - i];
                order[5 - i] = temp;
            }
            inout[1] = string.Join(string.Empty, order.ToArray());
            Debug.LogFormat("[UltraStores #{0}]Rule 1 applies: {1} -> {2}", moduleID, inout[0], inout[1]);
        }
        if(cycle.IndexOf("Y") == 1)
        {
            inout[0] = string.Join(string.Empty, order.ToArray());
            temp = order[0];
            for(int i = 0; i < 5; i++)
            {
                order[i] = order[i + 1];
            }
            order[5] = temp;
            inout[1] = string.Join(string.Empty, order.ToArray());
            Debug.LogFormat("[UltraStores #{0}]Rule 2 applies: {1} -> {2}", moduleID, inout[0], inout[1]);
        }
        if(cycle.IndexOf("W") % 4 == cycle.IndexOf("K") % 4)
        {
            inout[0] = string.Join(string.Empty, order.ToArray());
            for (int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(order[i] == cycle[j])
                    {
                        order[i] = cycle[(j + 4) % 8];
                        break;
                    }
                }
            }
            inout[1] = string.Join(string.Empty, order.ToArray());
            Debug.LogFormat("[UltraStores #{0}]Rule 3 applies: {1} -> {2}", moduleID, inout[0], inout[1]);
        }
        if(cycle.IndexOf("R") % 4 == cycle.IndexOf("C") % 4)
        {
            inout[0] = string.Join(string.Empty, order.ToArray());
            for (int i = 0; i < 6; i++)
            {
                switch (order[i])
                {
                    case "R":
                        order[i] = "C";
                        break;
                    case "G":
                        order[i] = "M";
                        break;
                    case "B":
                        order[i] = "Y";
                        break;
                    case "C":
                        order[i] = "R";
                        break;
                    case "M":
                        order[i] = "G";
                        break;
                    default:
                        order[i] = "B";
                        break;
                }
            }
            inout[1] = string.Join(string.Empty, order.ToArray());
            Debug.LogFormat("[UltraStores #{0}]Rule 4 applies: {1} -> {2}", moduleID, inout[0], inout[1]);
        }
        if (Mathf.Abs(cycle.IndexOf("G") - cycle.IndexOf("M")) == 2 || Mathf.Abs(cycle.IndexOf("G") - cycle.IndexOf("M")) == 6)
        {
            inout[0] = string.Join(string.Empty, order.ToArray());
            List<string> cycol = new List<string> { };
            for(int i = 0; i < 8; i++)
            {
                if(cycle[i] != "W" && cycle[i] != "K")
                {
                    cycol.Add(cycle[i]);
                }
            }
            for(int i = 0; i < 6; i++)
            {
                order[i] = cycol[(cycol.IndexOf(order[i]) + 1) % 6];
            }
            inout[1] = string.Join(string.Empty, order.ToArray());
            Debug.LogFormat("[UltraStores #{0}]Rule 5 applies: {1} -> {2}", moduleID, inout[0], inout[1]);
        }
        if(Mathf.Abs(cycle.IndexOf("W") - cycle.IndexOf("G")) == 1 || Mathf.Abs(cycle.IndexOf("W") - cycle.IndexOf("G")) == 7)
        {
            inout[0] = string.Join(string.Empty, order.ToArray());
            for (int i = 0; i < 6; i++)
            {
                switch (order[i])
                {
                    case "R":
                        order[i] = "G";
                        break;
                    case "G":
                        order[i] = "B";
                        break;
                    case "B":
                        order[i] = "R";
                        break;
                }
            }
            inout[1] = string.Join(string.Empty, order.ToArray());
            Debug.LogFormat("[UltraStores #{0}]Rule 6 applies: {1} -> {2}", moduleID, inout[0], inout[1]);
        }
        if (Mathf.Abs(cycle.IndexOf("K") - cycle.IndexOf("M")) == 1 || Mathf.Abs(cycle.IndexOf("K") - cycle.IndexOf("M")) == 7)
        {
            inout[0] = string.Join(string.Empty, order.ToArray());
            for (int i = 0; i < 6; i++)
            {
                switch (order[i])
                {
                    case "C":
                        order[i] = "M";
                        break;
                    case "M":
                        order[i] = "Y";
                        break;
                    case "Y":
                        order[i] = "C";
                        break;
                }
            }
            inout[1] = string.Join(string.Empty, order.ToArray());
            Debug.LogFormat("[UltraStores #{0}]Rule 7 applies: {1} -> {2}", moduleID, inout[0], inout[1]);
        }
        if (Mathf.Abs(cycle.IndexOf("W") - cycle.IndexOf("K")) == 1 || Mathf.Abs(cycle.IndexOf("W") - cycle.IndexOf("K")) == 7)
        {
            inout[0] = string.Join(string.Empty, order.ToArray());
            for (int i = 0; i < 6; i++)
            {
                switch (order[i])
                {
                    case "R":
                        order[i] = "G";
                        break;
                    case "G":
                        order[i] = "B";
                        break;
                    case "B":
                        order[i] = "R";
                        break;
                    case "C":
                        order[i] = "M";
                        break;
                    case "M":
                        order[i] = "Y";
                        break;
                    default:
                        order[i] = "C";
                        break;
                }
            }
            inout[1] = string.Join(string.Empty, order.ToArray());
            Debug.LogFormat("[UltraStores #{0}]Rule 8 applies: {1} -> {2}", moduleID, inout[0], inout[1]);
        }
        int tempnum = 0;
        if ( (cycle.IndexOf("B") > 4 && cycle.IndexOf("Y") > 4) || (cycle.IndexOf("B") > 0 && cycle.IndexOf("Y") > 0 && cycle.IndexOf("B") < 4 && cycle.IndexOf("Y") < 4))
        {
            inout[0] = string.Join(string.Empty, order.ToArray());
            tempnum = order.IndexOf("B");
            order[tempnum] = order[5 - tempnum];
            order[5 - tempnum] = "B";
            inout[1] = string.Join(string.Empty, order.ToArray());
            Debug.LogFormat("[UltraStores #{0}]Rule 9 applies: {1} -> {2}", moduleID, inout[0], inout[1]);
        }
        if( cycle.IndexOf("R") > 0 && cycle.IndexOf("R") < 4)
        {
            inout[0] = string.Join(string.Empty, order.ToArray());
            tempnum = order.IndexOf("R");
            int tempnum2 = order.IndexOf("Y");
            order[tempnum] = "Y";
            order[tempnum2] = "R";
            inout[1] = string.Join(string.Empty, order.ToArray());
            Debug.LogFormat("[UltraStores #{0}]Rule 10 applies: {1} -> {2}", moduleID, inout[0], inout[1]);
        }
        if (cycle.IndexOf("B") > 4)
        {
            inout[0] = string.Join(string.Empty, order.ToArray());
            tempnum = order.IndexOf("G");
            int tempnum2 = order.IndexOf("C");
            order[tempnum] = "C";
            order[tempnum2] = "G";
            inout[1] = string.Join(string.Empty, order.ToArray());
            Debug.LogFormat("[UltraStores #{0}]Rule 11 applies: {1} -> {2}", moduleID, inout[0], inout[1]);
        }
        int k = 1;
        bool rule12 = false;
        while ((cycle.IndexOf("W") + k) % 8 != cycle.IndexOf("Y"))
        {
            if ((cycle.IndexOf("W") + k) % 8 == cycle.IndexOf("G"))
            {
                rule12 = true;
            }
            k++;
        }
        if(rule12 == true)
        {
            inout[0] = string.Join(string.Empty, order.ToArray());
            temp = order[0];
            order[0] = order[5];
            order[5] = temp;
            inout[1] = string.Join(string.Empty, order.ToArray());
            Debug.LogFormat("[UltraStores #{0}]Rule 12 applies: {1} -> {2}", moduleID, inout[0], inout[1]);
        }
        int l = 1;
        bool rule13 = false;
        while ((cycle.IndexOf("K") + l) % 8 != cycle.IndexOf("B"))
        {
            if ((cycle.IndexOf("K") + l) % 8 == cycle.IndexOf("C"))
            {
                rule13 = true;
            }
            l++;
        }
        if (rule13 == true && !(cycle[0] == "W" || cycle[0] == "K" || cycle[4] == "W" || cycle[4] == "K"))
        {
            inout[0] = string.Join(string.Empty, order.ToArray());
            for (int i = 0; i < 6; i++)
            {
                if(order[i] == cycle[0])
                {
                    order[i] = cycle[4];
                }
                else if(order[i] == cycle[4])
                {
                    order[i] = cycle[0];
                }
            }
            inout[1] = string.Join(string.Empty, order.ToArray());
            Debug.LogFormat("[UltraStores #{0}]Rule 13 applies: {1} -> {2}", moduleID, inout[0], inout[1]);
        }
        inout[0] = string.Join(string.Empty, order.ToArray());
        Debug.LogFormat("[UltraStores #{0}]The pressing order was {1}", moduleID, inout[0]);
        subwaiting = false;
        answer[0] = string.Empty;
        for (int i = 0; i < 6; i++)
        {
            if (balter[5 - i] != "0")
            {
                answer[0] += balter[5 - i] + order[i];
            }
        }
        Debug.LogFormat("[UltraStores #{0}]The correct input for stage {1} is {2}", moduleID, stage + 1, answer[0], inout[1]);
    }

    private IEnumerator Submit()
    {
        for (int i = 0; i < 8 * (stage + 1); i++)
        {
            brends[(i + 7) % 8].material = buttoncols["WRGBCMYK".IndexOf(cycle[(i + 7) % 8])];
            brends[i % 8].material = unlitcols["WRGBCMYK".IndexOf(cycle[i % 8])];
            yield return new WaitForSeconds(0.2f / (stage + 1));
        }
        Debug.LogFormat("[UltraStores #{0}]The submitted answer was: {1}", moduleID, answer[1]);
        if(answer[0] == answer[1])
        {
            Audio.PlaySoundAtTransform("InputCorrect", transform);
            if(stage < 2)
            {
                stage++;
                Generate();
            }
            else
            {
                GetComponent<KMBombModule>().HandlePass();
                moduleSolved = true;
            }
        }
        else
        {
            GetComponent<KMBombModule>().HandleStrike();
        }
        answer[1] = string.Empty;
        yield return StartCoroutine(StartCube());
    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} start/submit [presses centre button] RKMCWB [presses coloured buttons; K = black] | !{0} cycle [shows colours of buttons in clockwise order]";
#pragma warning restore 414

    public IEnumerator ProcessTwitchCommand(string command)
    {
        if (Regex.IsMatch(command, @"^\s*cycle\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            if (submissable == true && subwaiting == false)
            {
                yield return null;
                for (int i = 0; i < 8; i++)
                {
                    buttons[i].OnHighlight();
                    yield return new WaitForSeconds(1.2f);
                    buttons[i].OnHighlightEnded();
                    yield return new WaitForSeconds(.1f);
                }
            }
            else
            {
                yield return "sendtochaterror UltraStores is not in input mode. Use \"start\" to initiate input mode.";
            }
        }
        else if (Regex.IsMatch(command, @"^\s*start\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            if (submissable == false && subwaiting == false)
            {
                yield return null;
                buttons[8].OnInteract();
            }
            else
            {
                yield return "sendtochaterror UltraStores is already in input mode.";
            }
        }
        else if (Regex.IsMatch(command, @"^\s*submit\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            if (submissable == true && subwaiting == false)
            {
                yield return null;
                yield return "solve";
                yield return "strike";
                buttons[8].OnInteract();
            }
            else
            {
                yield return "sendtochaterror UltraStores is not in input mode. Use \"start\" to initiate input mode.";
            }
        }
        else
        {
            var m = Regex.Match(command, @"^\s*([WKRMGBCY, ]+)\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            if (!m.Success)
                yield break;
            if (submissable == true && subwaiting == false)
            {
                command = command.ToUpperInvariant();
                yield return null;
                foreach (char ch in command)
                {
                    buttons[cycle.IndexOf(ch.ToString())].OnInteract();
                    if (ch != 'W' && ch != 'K')
                    {
                        yield return new WaitForSeconds(0.5f);
                    }
                }
            }
            else
            {
                yield return "sendtochaterror UltraStores is not in input mode. Use \"start\" to initiate input mode.";
            }
        }
    }
}
