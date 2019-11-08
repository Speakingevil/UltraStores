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

    private int[][][] rotmatrices = new int[30][][]
    {
        new int[6][] {new int[6] { 0, -1,  0,  0,  0,  0},
                      new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 0,  0, -1,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0, -1,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 0,  0,  0, -1,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0, -1,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0, -1,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 0,  0,  0,  0, -1,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0, -1,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0, -1,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0, -1,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 0,  0,  0,  0,  0, -1},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 1,  0,  0,  0,  0,  0} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0, -1},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0, -1},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0, -1},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0, -1},
                      new int[6] { 0,  0,  0,  0,  1,  0} },

        new int[6][] {new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] {-1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] {-1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0, -1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] {-1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0, -1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0, -1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] {-1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0, -1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0, -1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0, -1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1} },

        new int[6][] {new int[6] { 0,  0,  0,  0,  0,  1},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] {-1,  0,  0,  0,  0,  0} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0, -1,  0,  0,  0,  0} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0, -1,  0,  0,  0} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1},
                      new int[6] { 0,  0,  0,  0,  1,  0},
                      new int[6] { 0,  0,  0, -1,  0,  0} },

        new int[6][] {new int[6] { 1,  0,  0,  0,  0,  0},
                      new int[6] { 0,  1,  0,  0,  0,  0},
                      new int[6] { 0,  0,  1,  0,  0,  0},
                      new int[6] { 0,  0,  0,  1,  0,  0},
                      new int[6] { 0,  0,  0,  0,  0,  1},
                      new int[6] { 0,  0,  0,  0, -1,  0} },
       };
    private List<string>[][] rotations = new List<string>[3][] {new List<string>[1] { new List<string>{ "XY", "XZ", "YZ", "XW", "YW", "ZW", "XV", "YV", "ZV", "WV", "XU", "YU", "ZU", "WU", "VU", "YX", "ZX", "ZY", "WX", "WY", "WZ", "VX", "VY", "VZ", "VW", "UX", "UY", "UZ", "UW", "UV" } },
                                                  new List<string>[15] { new List<string> { "(XY, ZW)", "(XY, ZV)", "(XY, ZU)", "(XY, WV)", "(XY, WU)", "(XY, VU)", "(XY, WZ)", "(XY, VZ)", "(XY, UZ)", "(XY, VW)", "(XY, UW)", "(XY, UV)"},
                                                                         new List<string> { "(XZ, YW)", "(XZ, YV)", "(XZ, YU)", "(XZ, YV)", "(XZ, WU)", "(XZ, VU)", "(XZ, WY)", "(XZ, VY)", "(XZ, UY)", "(XZ, VW)", "(XZ, UW)", "(XZ, UV)"},
                                                                         new List<string> { "(YZ, XW)", "(YZ, XV)", "(YZ, XU)", "(YZ, WV)", "(YZ, WU)", "(YZ, VU)", "(YZ, WX)", "(YZ, VX)", "(YZ, UX)", "(YZ, VW)", "(YZ, UW)", "(YZ, UV)"},
                                                                         new List<string> { "(XW, YZ)", "(XW, YV)", "(XW, YU)", "(XW, ZV)", "(XW, ZU)", "(XW, VU)", "(XW, ZY)", "(XW, VY)", "(XW, UY)", "(XW, VZ)", "(XW, UZ)", "(XW, UV)"},
                                                                         new List<string> { "(YW, XZ)", "(YW, XV)", "(YW, XU)", "(YW, ZV)", "(YW, ZU)", "(YW, VU)", "(YW, ZX)", "(YW, VX)", "(YW, UX)", "(YW, VZ)", "(YW, UZ)", "(YW, UV)"},
                                                                         new List<string> { "(ZW, XY)", "(ZW, XV)", "(ZW, XU)", "(ZW, YV)", "(ZW, YU)", "(ZW, VU)", "(ZW, YX)", "(ZW, VX)", "(ZW, VY)", "(ZW, UX)", "(ZW, UY)", "(ZW, UV)"},
                                                                         new List<string> { "(XV, YZ)", "(XV, YW)", "(XV, YU)", "(XV, ZW)", "(XV, ZU)", "(XV, WU)", "(XV, ZY)", "(XV, WY)", "(XV, WZ)", "(XV, UY)", "(XV, UZ)", "(XV, UW)"},
                                                                         new List<string> { "(YV, XZ)", "(YV, XW)", "(YV, XU)", "(YV, ZW)", "(YV, ZU)", "(YV, WU)", "(YV, ZX)", "(YV, WX)", "(YV, WZ)", "(YV, UX)", "(YV, UZ)", "(YV, UW)"},
                                                                         new List<string> { "(ZV, XY)", "(ZV, XW)", "(ZV, XU)", "(ZV, YW)", "(ZV, YU)", "(ZV, WU)", "(ZV, YX)", "(ZV, WX)", "(ZV, WY)", "(ZV, UX)", "(ZV, UY)", "(ZV, UW)"},
                                                                         new List<string> { "(WV, XY)", "(WV, XZ)", "(WV, XU)", "(WV, YZ)", "(WV, YU)", "(WV, ZU)", "(WV, YX)", "(WV, ZX)", "(WV, UX)", "(WV, ZY)", "(WV, UY)", "(WV, UZ)"},
                                                                         new List<string> { "(XU, YZ)", "(XU, YW)", "(XU, YV)", "(XU, ZW)", "(XU, ZV)", "(XU, WV)", "(XU, ZY)", "(XU, WY)", "(XU, WZ)", "(XU, VY)", "(XU, VZ)", "(XU, VW)"},
                                                                         new List<string> { "(YU, XZ)", "(YU, XW)", "(YU, XV)", "(YU, ZW)", "(YU, ZV)", "(YU, WV)", "(YU, ZX)", "(YU, WX)", "(YU, WZ)", "(YU, VY)", "(YU, VZ)", "(YU, VW)"},
                                                                         new List<string> { "(ZU, XY)", "(ZU, YW)", "(ZU, YV)", "(ZU, XW)", "(ZU, XV)", "(ZU, WV)", "(ZU, YX)", "(ZU, WY)", "(ZU, WX)", "(ZU, VX)", "(ZU, VY)", "(ZU, VW)"},
                                                                         new List<string> { "(WU, XY)", "(WU, XZ)", "(WU, XV)", "(WU, YZ)", "(WU, YV)", "(WU, ZV)", "(WU, YX)", "(WU, ZX)", "(WU, ZY)", "(WU, VX)", "(WU, VY)", "(WU, VZ)"},
                                                                         new List<string> { "(VU, XY)", "(VU, XZ)", "(VU, XW)", "(VU, YZ)", "(VU, YW)", "(VU, ZW)", "(VU, YX)", "(VU, ZX)", "(VU, WX)", "(VU, ZY)", "(VU, WY)", "(VU, WZ)"} },
                                                  new List<string>[10] { new List<string> { "(XY, ZW, VU)", "(XY, ZW, UV)", "(XY, WZ, VU)", "(XY, WZ, UV)", "(XY, ZV, WU)", "(XY, ZV, UW)", "(XY, VZ, WU)", "(XY, VZ, UW)", "(XY, ZU, WV)", "(XY, ZU, VW)", "(XY, UZ, WV)", "(XY, UZ, VW)"},
                                                                         new List<string> { "(XZ, YW, VU)", "(XZ, YW, UV)", "(XZ, WY, VU)", "(XZ, WY, UV)", "(XZ, YV, WU)", "(XZ, YV, UW)", "(XZ, VY, WU)", "(XZ, VY, UW)", "(XZ, YU, WV)", "(XZ, YU, VW)", "(XZ, UY, WV)", "(XZ, UY, VW)"},
                                                                         new List<string> { "(XW, YZ, VU)", "(XW, YZ, UV)", "(XW, ZY, VU)", "(XW, ZY, UV)", "(XW, YV, ZU)", "(XW, YV, UZ)", "(XW, VY, ZU)", "(XW, VY, UZ)", "(XW, YU, ZV)", "(XW, YU, VZ)", "(XW, UY, ZV)", "(XW, UY, VZ)"},
                                                                         new List<string> { "(XV, YZ, WU)", "(XV, YZ, UW)", "(XV, ZY, WU)", "(XV, ZY, UW)", "(XV, YW, ZU)", "(XV, YW, UZ)", "(XV, WY, ZU)", "(XV, WY, UZ)", "(XV, YU, ZW)", "(XV, YU, WZ)", "(XV, UY, ZW)", "(XV, UY, WZ)"},
                                                                         new List<string> { "(XU, YZ, WV)", "(XU, YZ, VW)", "(XU, ZY, WV)", "(XU, ZY, VW)", "(XU, YW, ZV)", "(XU, YW, VZ)", "(XU, WY, ZV)", "(XU, WY, VZ)", "(XU, YV, ZW)", "(XU, YV, WZ)", "(XU, VY, ZW)", "(XU, VY, WZ)"},
                                                                         new List<string> { "(YX, ZW, VU)", "(YX, ZW, UV)", "(YX, WZ, VU)", "(YX, WZ, UV)", "(YX, ZV, WU)", "(YX, ZV, UW)", "(YX, VZ, WU)", "(YX, VZ, UW)", "(YX, ZU, WV)", "(YX, ZU, VW)", "(YX, UZ, WV)", "(YX, UZ, VW)"},
                                                                         new List<string> { "(ZX, YW, VU)", "(ZX, YW, UV)", "(ZX, WY, VU)", "(ZX, WY, UV)", "(ZX, YV, WU)", "(ZX, YV, UW)", "(ZX, VY, WU)", "(ZX, VY, UW)", "(ZX, YU, WV)", "(ZX, YU, VW)", "(ZX, UY, WV)", "(ZX, UY, VW)"},
                                                                         new List<string> { "(WX, YZ, VU)", "(WX, YZ, UV)", "(WX, ZY, VU)", "(WX, ZY, UV)", "(WX, YV, ZU)", "(WX, YV, UZ)", "(WX, VY, ZU)", "(WX, VY, UZ)", "(WX, YU, ZV)", "(WX, YU, VZ)", "(WX, UY, ZV)", "(WX, UY, VZ)"},
                                                                         new List<string> { "(VX, YZ, WU)", "(VX, YZ, UW)", "(VX, ZY, WU)", "(VX, ZY, UW)", "(VX, YW, ZU)", "(VX, YW, UZ)", "(VX, WY, ZU)", "(VX, WY, UZ)", "(VX, YU, ZW)", "(VX, YU, WZ)", "(VX, UY, ZW)", "(VX, UY, WZ)"},
                                                                         new List<string> { "(UX, YZ, WV)", "(UX, YZ, VW)", "(UX, ZY, WV)", "(UX, ZY, VW)", "(UX, YW, ZV)", "(UX, YW, VZ)", "(UX, WY, ZV)", "(UX, WY, VZ)", "(UX, YV, ZW)", "(UX, YV, WZ)", "(UX, VY, ZW)", "(UX, VY, WZ)"},} };
    private int[][] gen = new int[64][];
    private int[][] oldpos = new int[64][] { new int[6] { 1, 1, 1, 1, 1, 1 }, new int[6] { -1, 1, 1, 1, 1, 1 }, new int[6] { 1, -1, 1, 1, 1, 1 }, new int[6] { -1, -1, 1, 1, 1, 1 }, new int[6] { 1, 1, -1, 1, 1, 1 }, new int[6] { -1, 1, -1, 1, 1, 1 }, new int[6] { 1, -1, -1, 1, 1, 1 }, new int[6] { -1, -1, -1, 1, 1, 1 }, new int[6] { 1, 1, 1, -1, 1, 1 }, new int[6] { -1, 1, 1, -1, 1, 1 }, new int[6] { 1, -1, 1, -1, 1, 1 }, new int[6] { -1, -1, 1, -1, 1, 1 }, new int[6] { 1, 1, -1, -1, 1, 1 }, new int[6] { -1, 1, -1, -1, 1, 1 }, new int[6] { 1, -1, -1, -1, 1, 1 }, new int[6] { -1, -1, -1, -1, 1, 1 }, new int[6] { 1, 1, 1, 1, -1, 1 }, new int[6] { -1, 1, 1, 1, -1, 1 }, new int[6] { 1, -1, 1, 1, -1, 1 }, new int[6] { -1, -1, 1, 1, -1, 1 }, new int[6] { 1, 1, -1, 1, -1, 1 }, new int[6] { -1, 1, -1, 1, -1, 1 }, new int[6] { 1, -1, -1, 1, -1, 1 }, new int[6] { -1, -1, -1, 1, -1, 1 }, new int[6] { 1, 1, 1, -1, -1, 1 }, new int[6] { -1, 1, 1, -1, -1, 1 }, new int[6] { 1, -1, 1, -1, -1, 1 }, new int[6] { -1, -1, 1, -1, -1, 1 }, new int[6] { 1, 1, -1, -1, -1, 1 }, new int[6] { -1, 1, -1, -1, -1, 1 }, new int[6] { 1, -1, -1, -1, -1, 1 }, new int[6] { -1, -1, -1, -1, -1, 1 }, new int[6] { 1, 1, 1, 1, 1, -1 }, new int[6] { -1, 1, 1, 1, 1, -1 }, new int[6] { 1, -1, 1, 1, 1, -1 }, new int[6] { -1, -1, 1, 1, 1, -1 }, new int[6] { 1, 1, -1, 1, 1, -1 }, new int[6] { -1, 1, -1, 1, 1, -1 }, new int[6] { 1, -1, -1, 1, 1, -1 }, new int[6] { -1, -1, -1, 1, 1, -1 }, new int[6] { 1, 1, 1, -1, 1, -1 }, new int[6] { -1, 1, 1, -1, 1, -1 }, new int[6] { 1, -1, 1, -1, 1, -1 }, new int[6] { -1, -1, 1, -1, 1, -1 }, new int[6] { 1, 1, -1, -1, 1, -1 }, new int[6] { -1, 1, -1, -1, 1, -1 }, new int[6] { 1, -1, -1, -1, 1, -1 }, new int[6] { -1, -1, -1, -1, 1, -1 }, new int[6] { 1, 1, 1, 1, -1, -1 }, new int[6] { -1, 1, 1, 1, -1, -1 }, new int[6] { 1, -1, 1, 1, -1, -1 }, new int[6] { -1, -1, 1, 1, -1, -1 }, new int[6] { 1, 1, -1, 1, -1, -1 }, new int[6] { -1, 1, -1, 1, -1, -1 }, new int[6] { 1, -1, -1, 1, -1, -1 }, new int[6] { -1, -1, -1, 1, -1, -1 }, new int[6] { 1, 1, 1, -1, -1, -1 }, new int[6] { -1, 1, 1, -1, -1, -1 }, new int[6] { 1, -1, 1, -1, -1, -1 }, new int[6] { -1, -1, 1, -1, -1, -1 }, new int[6] { 1, 1, -1, -1, -1, -1 }, new int[6] { -1, 1, -1, -1, -1, -1 }, new int[6] { 1, -1, -1, -1, -1, -1 }, new int[6] { -1, -1, -1, -1, -1, -1 } };
    private int[][] newpos = new int[64][];
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
    private bool recol;
    private bool randrecol;
    private int stage;
    private string[] funcseq = new string[5];
    private string[] funccatch = new string[4];
    private int sound;

    private static int moduleIDCounter = 1;
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
                    subwaiting = true;
                }
                else
                {
                    subwaiting = true;
                    submissable = false;
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
            else if(recol == false)
            {
                if (b == 0)
                {
                    recol = true;
                    randrecol = false;
                    StartCoroutine(Recolour());
                }
                else if(b == 4)
                {
                    recol = true;
                    randrecol = true;
                    StartCoroutine(Recolour());
                }
            }
        }
    }

    private void Generate()
    {
        matrixlist.Clear();
        rotlist.Clear();
        List<int> selector = new List<int> { 0, 0, 0, 0, 0, 1, 2 };
        for(int i = 0; i < stage + 3; i++)
        {
            int r = Random.Range(0, selector.Count);
            int s = selector[r];
            selector.RemoveAt(r);
            if (s == 0)
            {
                int g = Random.Range(0, 20);
                rotlist.Add(rotations[0][0][g]);
                matrixlist.Add(rotmatrices[g]);
                vals[stage][i + 1] = SingRot(vals[stage][i], i, stage, g);
            }
            else if (s == 1)
            {
                int[] g = new int[2] { Random.Range(0, 15), Random.Range(0, 12) };
                string pair = rotations[1][g[0]][g[1]];
                rotlist.Add(pair);
                string[] indrot = new string[2] { string.Join(string.Empty, new string[2] {pair[1].ToString(), pair[2].ToString()}), string.Join(string.Empty, new string[2] { pair[5].ToString(), pair[6].ToString() } )};
                int[][][] mat = new int[2][][] { rotmatrices[rotations[0][0].IndexOf(indrot[0])], rotmatrices[rotations[0][0].IndexOf(indrot[1])] };
                matrixlist.Add(MatrixMultiply(mat[0], mat[1]));
                int[] rs = new int[3] { rotations[0][0].IndexOf(indrot[0]), rotations[0][0].IndexOf(indrot[1]), 0 };

                List<char> reductor = new List<char> { 'X', 'Y', 'Z', 'W', 'V', 'U'};
                for (int k = 0; k < pair.Length; k++)
                {
                    if (reductor.Contains(pair[k]))
                    {
                        reductor.Remove(pair[k]);
                    }
                }
                if("XYZ".Contains(reductor[0]) && "XYZ".Contains(reductor[1]))
                {
                    rs[2] = 0;
                }
                else if ("WVU".Contains(reductor[0]) && "WVU".Contains(reductor[1]))
                {
                    rs[2] = 2;
                }
                else
                {
                    rs[2] = 1;
                }

                vals[stage][i + 1] = DualRot(vals[stage][i], i, stage, rs);
            }
            else
            {
                int[] g = new int[2] { Random.Range(0, 10), Random.Range(0, 12) };
                string triplet = rotations[2][g[0]][g[1]];
                rotlist.Add(triplet);
                string[] indrot = new string[3] { string.Join(string.Empty, new string[2] { triplet[1].ToString(), triplet[2].ToString() }), string.Join(string.Empty, new string[2] { triplet[5].ToString(), triplet[6].ToString() }), string.Join(string.Empty, new string[2] { triplet[9].ToString(), triplet[10].ToString() })};
                int[][][] mat = new int[3][][] { rotmatrices[rotations[0][0].IndexOf(indrot[0])], rotmatrices[rotations[0][0].IndexOf(indrot[1])], rotmatrices[rotations[0][0].IndexOf(indrot[2])] };
                matrixlist.Add(MatrixMultiply(MatrixMultiply(mat[0], mat[1]), mat[2]));
                int[] rs = new int[4] { rotations[0][0].IndexOf(indrot[0]), rotations[0][0].IndexOf(indrot[1]), rotations[0][0].IndexOf(indrot[2]), 0 };
                if(indrot[0] == "XY" || indrot[0] == "YX" || indrot[0] == "XZ" || indrot[0] == "ZX" || indrot[1] == "YZ" || indrot[1] == "ZY")
                {
                    rs[3] = 1;
                }
                vals[stage][i + 1] = TripRot(vals[stage][i], i, stage, rs);
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

    private int[][] MatrixMultiply(int[][] a, int[][] b)
    {
        int[][] prod = new int[6][] { new int[6], new int[6], new int[6], new int[6], new int[6], new int[6]};
        for(int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                int n = 0;
                for (int k = 0; k < 6; k++)
                {
                    n += a[i][k] * b[k][j];
                }
                prod[i][j] = n;
            }
        }
        return prod;
    }

    private void VectorMultiply(int[][] a, int[] b, int c)
    {
        int[] prod = new int[6];
        for (int i = 0; i < 6; i++)
        {
            int n = 0;
            for (int j = 0; j < 6; j++)
            {
                n += a[i][j] * b[j];               
            }
            prod[i] = n;
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
                        x = (x * 2) - D;
                        funcseq[i] = "XZ(" + v + ") = " + v + "*2" + " - " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = (x * 2) - vals[0][i];
                        funcseq[i] = "XZ(" + v + ") = " + v + "*2" + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = (x * 2) - vals[1][i] - vals[0][i];
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
                        x += (2 * vals[1][i]) - vals[0][i];
                        funcseq[i] = "YZ(" + v + ") = " + v + " + " + vals[1][i] + "*2" + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 3:
                switch (j)
                {
                    case 0:
                        x = (2 * D) - x;
                        funcseq[i] = "XW(" + v + ") = " + D + "*2" + " - " + v + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = (3 * D) - x - vals[0][i];
                        funcseq[i] = "XW(" + v + ") = " + D + "*3" + " - " + v + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = (4 * D) - x - vals[1][i] - vals[0][i];
                        funcseq[i] = "XW(" + v + ") = " + D + "*4" + " - " + v + " - " + vals[1][i] + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 4:
                switch (j)
                {
                    case 0:
                        x = (2 * x) + D - (35 * (i + 1));
                        funcseq[i] = "YW(" + v + ") = " + v + "*2" + " + " + D + " - 35*" + (i + 1) + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = (2 * x) + Mathf.Abs(vals[0][i]) - (12 * (int)Mathf.Pow(i + 1, 2));
                        funcseq[i] = "YW(" + v + ") = " + v + "*2" + " + |" + vals[0][i] + "| - 12*(" + (i + 1) + "^2) = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = (2 * x) + Mathf.Abs(vals[1][i]) + Mathf.Abs(vals[0][i]) - (5 * (int)Mathf.Pow(i + 1, 3));
                        funcseq[i] = "YW(" + v + ") = " + v + "*2" + " + |" + vals[1][i] + "| + |" + vals[0][i] + "| - 5*(" + (i + 1) + "^3) = " + x + " ≈ " + (x + 7300) % 365;
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
                        x = (2 * x) - (3 * (D - vals[0][i]));
                        funcseq[i] = "XV(" + v + ") = " + v + "*2 - " + "( " + D + " - " + vals[0][i] + " )*3 = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = (2 * x) - (4 * (D - vals[1][i]));
                        funcseq[i] = "XV(" + v + ") = " + v + "*2 - " + "( " + D + " - " + vals[1][i] + " )*4 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 7:
                switch (j)
                {
                    case 0:
                        x += (int)Mathf.Pow(D % 6, 3) - (35 * (i + 1));
                        funcseq[i] = "YV(" + v + ") = " + v + " + " + (D % 6) + "^3 - 35*" + (i + 1) + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += (int)Mathf.Pow((vals[0][i] + 700) % 7, 3) - (12 * (int)Mathf.Pow(i + 1, 2));
                        funcseq[i] = "YV(" + v + ") = " + v + " + " + (vals[0][i] + 700) % 6 + "^3 - 12*(" + (i + 1) + "^2) = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x += (int)Mathf.Pow((vals[1][i] + 800) % 8, 3) - (5 * (int)Mathf.Pow(i + 1, 3));
                        funcseq[i] = "YV(" + v + ") = " + v + " + " + (vals[1][i] + 800) % 8 + "^3 - 5*(" + (i + 1) + "^3) = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 8:
                switch (j)
                {
                    case 0:
                        x = D + ((x - (x + 730) % 2) / 2);
                        funcseq[i] = "ZV(" + v + ") = " + (v - (v + 730) % 2) / 2 + " + " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += ((x - (x + 730) % 2) / 2) - vals[0][i];
                        funcseq[i] = "ZV(" + v + ") = " + v + " + " + (v - (v + 730) % 2) / 2 + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = (2 * vals[1][i]) + (x - (x + 365 * (i + 1)) % (i + 1)) / (i + 1);
                        funcseq[i] = "ZV(" + v + ") = " + (v - (v + 365 * (i + 1)) % (i + 1)) / (i + 1) + " + " + vals[1][i] + "*2 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 9:
                switch (j)
                {
                    case 0:
                        x = (5 * x) - (3 * D);
                        funcseq[i] = "WV(" + v + ") = " + v + "*5 - " + D + "*3 = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = (8 * x) - (5 * D) + (3 * vals[0][i]);
                        funcseq[i] = "WV(" + v + ") = " + v + "*8 - " + D + "*5 + " + vals[0][i] + "*3 = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = (13 * x) - (8 * D) + (5 * vals[0][i]) - (3 * vals[1][i]);
                        funcseq[i] = "WV(" + v + ") = " + v + "*13 - " + D + "*8 + " + vals[0][i] + "*5 - " + vals[1][i] + "*3 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 10:
                switch (j)
                {
                    case 0:
                        x += 365 - D;
                        funcseq[i] = "XU(" + v + ") = " + v + " + 365 - " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += 365 - Mathf.Abs(vals[0][i]);
                        funcseq[i] = "XU(" + v + ") = " + v + " + 365 - |" + vals[0][i] + "| = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x += 365 - Mathf.Abs(vals[0][i]) - Mathf.Abs(vals[1][i]);
                        funcseq[i] = "XU(" + v + ") = " + v + " + 365 - |" + vals[0][i] + "| - |" + vals[1][i] + "| = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 11:
                switch (j)
                {
                    case 0:
                        x =  2 * x - 365 + D;
                        funcseq[i] = "YU(" + v + ") = " + v + "*2 - 365 + " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = 2 * x - 365 + Mathf.Abs(vals[0][i]);
                        funcseq[i] = "YU(" + v + ") = " + v + "*2 - 365 + |" + vals[0][i] + "| = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = 2 * x - 365 + Mathf.Abs(vals[0][i]) + Mathf.Abs(vals[1][i]);
                        funcseq[i] = "YU(" + v + ") = " + v + "*2 - 365 + |" + vals[0][i] + "| + |" + vals[1][i] + "| = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 12:
                switch (j)
                {
                    case 0:
                        x += 365 - 2 * D;
                        funcseq[i] = "ZU(" + v + ") = " + v + " + 365 - " + D + "*2 = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += 365 - 2 * Mathf.Abs(vals[0][i]);
                        funcseq[i] = "ZU(" + v + ") = " + v + " + 365 - |" + vals[0][i] + "|*2 = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x += 365 - 2 * Mathf.Abs(vals[0][i]) - 2 * Mathf.Abs(vals[1][i]);
                        funcseq[i] = "ZU(" + v + ") = " + v + " + 365 - |" + vals[0][i] + "|*2 - |" + vals[1][i] + "|*2 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 13:
                switch (j)
                {
                    case 0:
                        x = 365 - Mathf.Abs(x);
                        funcseq[i] = "WU(" + v + ") = 365 - |" + v + "| = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = 365 - Mathf.Abs(x) - Mathf.Abs(vals[0][i]);
                        funcseq[i] = "WU(" + v + ") = 365 - |" + v + "| - |" + vals[0][i] + "| = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = 365 - Mathf.Abs(x) - Mathf.Abs(vals[0][i]) - Mathf.Abs(vals[1][i]);
                        funcseq[i] = "WU(" + v + ") = 365 - |" + v + "| - |" + vals[0][i] + "| - |" + vals[1][i] + "| = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 14:
                switch (j)
                {
                    case 0:
                        x = (i + 1)*x;
                        funcseq[i] = "VU(" + v + ") = " + v + "*" + (i + 1) + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = (i + 1) * (x - vals[0][i]);
                        funcseq[i] = "VU(" + v + ") = (" + v + " - " + vals[0][i] + ")*" + (i + 1) + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = (i + 1) * (x - vals[0][i] + vals[1][0]);
                        funcseq[i] = "VU(" + v + ") = (" + v + " - " + vals[0][i] + " + " + vals[1][i] + ")*" + (i + 1) + " = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 15:
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
            case 16:
                switch (j)
                {
                    case 0:
                        x = (x * 2) + D;
                        funcseq[i] = "ZX(" + v + ") = " + v + "*2" + " + " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = (x * 2) + vals[0][i];
                        funcseq[i] = "ZX(" + v + ") = " + v + "*2" + " + " + D + " = " + x + " ≈ " +x % 365;
                        break;
                    default:
                        x = vals[1][i] + vals[0][i] - (2 * x);
                        funcseq[i] = "ZX(" + v + ") = " + vals[1][i] + " + " + vals[0][i] + " - " + v + "*2 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 17:
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
                        x += (2 * vals[0][i]) - vals[1][i];
                        funcseq[i] = "ZY(" + v + ") = " + v + " + " + vals[0][i] + "*2 - " + vals[1][i] + " = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 18:
                switch (j)
                {
                    case 0:
                        x += 2 * D;
                        funcseq[i] = "WX(" + v + ") = " + v + " + " + D + "*2" + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += (3 * D) - vals[0][i];
                        funcseq[i] = "WX(" + v + ") = " + v + " + " + D + "*3" + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x += (4 * D) - vals[1][i] - vals[0][i];
                        funcseq[i] = "WX(" + v + ") = " + v + " + " + D + "*4" + " - " + vals[1][i] + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 19:
                switch (j)
                {
                    case 0:
                        x = (2 * x) - D - 35 * (i + 1);
                        funcseq[i] = "WY(" + v + ") = " + v + "*2 - " + D + " - 35*" + (i + 1) + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = (2 * x) - Mathf.Abs(vals[0][i]) - (12 * (int)Mathf.Pow(i + 1, 2));
                        funcseq[i] = "WY(" + v + ") = " + v + "*2" + " - |" + vals[0][i] + "| - 12*(" + (i + 1) + "^2) = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = (2 * x) - Mathf.Abs(vals[1][i]) - Mathf.Abs(vals[0][i]) - (5 * (int)Mathf.Pow(i + 1, 3));
                        funcseq[i] = "WY(" + v + ") = " + v + "*2" + " - |" + vals[1][i] + "| - |" + vals[0][i] + "| - 5*(" + (i + 1) + "^3) = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 20:
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
            case 21:
                switch (j)
                {
                    case 0:
                        x = 2 * (D + x);
                        funcseq[i] = "VX(" + v + ") = " + "( " + D + " + " + v + " )*2 = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = (2 * x) - (3 * (D + vals[0][i]));
                        funcseq[i] = "VX(" + v + ") = " + v + "*2 - " + "( " + D + " + " + vals[0][i] + " )*3 = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = (2 * x) - (4 * (D + vals[1][i]));
                        funcseq[i] = "VX(" + v + ") = " + v + "*2 - " + "( " + D + " + " + vals[1][i] + " )*4 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 22:
                switch (j)
                {
                    case 0:
                        x -= (int)Mathf.Pow(D % 6, 3) + (35 * (i + 1));
                        funcseq[i] = "VY(" + v + ") = " + v + " - " + (D % 6) + "^3 - 35*" + (i + 1) + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x -= (int)Mathf.Pow((vals[0][i] + 700) % 7, 3) + (12 * (int)Mathf.Pow(i + 1, 2));
                        funcseq[i] = "VY(" + v + ") = " + v + " - " + (vals[0][i] + 700) % 6 + "^3 - 12*(" + (i + 1) + "^2) = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x -= (int)Mathf.Pow((vals[1][i] + 800) % 8, 3) + (5 * (int)Mathf.Pow(i + 1, 3));
                        funcseq[i] = "VY(" + v + ") = " + v + " - " + (vals[1][i] + 800) % 8 + "^3 - 5*(" + (i + 1) + "^3) = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 23:
                switch (j)
                {
                    case 0:
                        x = ((x - ((x + 730) % 2)) / 2) - D;
                        funcseq[i] = "VZ(" + v + ") = " + (v - (v + 730) % 2) / 2 + " - " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += vals[0][i] + ((x - ((x + 730) % 2)) / 2);
                        funcseq[i] = "VZ(" + v + ") = " + v + " + " + (v - (v + 730) % 2) / 2 + " + " + vals[0][i] + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = (x - (x + (365 * (i + 1))) % (i + 1)) / (i + 1) - (2 * vals[1][i]);
                        funcseq[i] = "VZ(" + v + ") = " + (v - (v + 365 * (i + 1)) % (i + 1)) / (i + 1) + " - " + vals[1][i] + "*2 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 24:
                switch (j)
                {
                    case 0:
                        x = (5 * x) + (3 * D);
                        funcseq[i] = "VW(" + v + ") = " + v + "*5 + " + D + "*3 = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = (8 * x)+ (5 * D) - (3 * vals[0][i]);
                        funcseq[i] = "VW(" + v + ") = " + v + "*8 + " + D + "*5 - " + vals[0][i] + "*3 = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = (13 * x) + (8 * D) - (5 * vals[0][i]) + (3 * vals[1][i]);
                        funcseq[i] = "VW(" + v + ") = " + v + "*13 + " + D + "*8 - " + vals[0][i] + "*5 + " + vals[1][i] + "*3 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 25:
                switch (j)
                {
                    case 0:
                        x -= 365 + D;
                        funcseq[i] = "UX(" + v + ") = " + v + " - 365 - " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x -= 365 + Mathf.Abs(vals[0][i]);
                        funcseq[i] = "UX(" + v + ") = " + v + " - 365 - |" + vals[0][i] + "| = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x -= 365 - Mathf.Abs(vals[0][i]) + Mathf.Abs(vals[1][i]);
                        funcseq[i] = "UX(" + v + ") = " + v + " - 365 + |" + vals[0][i] + "| - |" + vals[1][i] + "| = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 26:
                switch (j)
                {
                    case 0:
                        x = 2 * x - 365 - D;
                        funcseq[i] = "UY(" + v + ") = " + v + "*2 - 365 - " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = 2 * x - 365 - Mathf.Abs(vals[0][i]);
                        funcseq[i] = "UY(" + v + ") = " + v + "*2 - 365 - |" + vals[0][i] + "| = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = 2 * x - 365 + Mathf.Abs(vals[0][i]) - Mathf.Abs(vals[1][i]);
                        funcseq[i] = "UY(" + v + ") = " + v + "*2 + 365 - |" + vals[0][i] + "| - |" + vals[1][i] + "| = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 27:
                switch (j)
                {
                    case 0:
                        x += 365 + 2 * D;
                        funcseq[i] = "UZ(" + v + ") = " + v + " + 365 - " + D + "*2 = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x += 365 + 2 * Mathf.Abs(vals[0][i]);
                        funcseq[i] = "UZ(" + v + ") = " + v + " + 365 + |" + vals[0][i] + "|*2 = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x += 365 + 2 * Mathf.Abs(vals[0][i]) - 2 * Mathf.Abs(vals[1][i]);
                        funcseq[i] = "UZ(" + v + ") = " + v + " + 365 + |" + vals[0][i] + "|*2 - |" + vals[1][i] + "|*2 = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 28:
                switch (j)
                {
                    case 0:
                        x = 365 - 2 * Mathf.Abs(x);
                        funcseq[i] = "UW(" + v + ") = 365 - |" + v + "|*2 = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = 365 - 2 * Mathf.Abs(x) - Mathf.Abs(vals[0][i]);
                        funcseq[i] = "UW(" + v + ") = 365 - |" + v + "|*2 - |" + vals[0][i] + "| = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = 365 - 2 * Mathf.Abs(x) - Mathf.Abs(vals[0][i]) - Mathf.Abs(vals[1][i]);
                        funcseq[i] = "UW(" + v + ") = 365 - |" + v + "|*2 - |" + vals[0][i] + "| - |" + vals[1][i] + "| = " + x + " ≈ " + x % 365;
                        break;
                }
                break;
            case 29:
                switch (j)
                {
                    case 0:
                        x = (i + 1) * x - D;
                        funcseq[i] = "UV(" + v + ") = " + v + "*" + (i + 1) + " - " + D + " = " + x + " ≈ " + x % 365;
                        break;
                    case 1:
                        x = (i + 1) * (x - vals[0][i] - D);
                        funcseq[i] = "UV(" + v + ") = (" + v + " - " + vals[0][i] + " - " + D + ")*" + (i + 1) + " = " + x + " ≈ " + x % 365;
                        break;
                    default:
                        x = (i + 1) * (x - vals[0][i] - vals[1][0]);
                        funcseq[i] = "UV(" + v + ") = (" + v + " - " + vals[0][i] + " - " + vals[1][i] + ")*" + (i + 1) + " = " + x + " ≈ " + x % 365;
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
                        funcseq[i] = "X(" + v + ") = 2*" + D + " - |[" + SingRot(v, i, j, k[0]) + "] - [" + SingRot(v, i, j, k[1]) + "]| = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1];
                        break;
                    case 1:
                        x = 3 * D - Mathf.Abs(SingRot(x, i, j, k[0]) + SingRot(x, i, j, k[1]));
                        funcseq[i] = "X(" + v + ") = 3*" + D + " - |[" + SingRot(v, i, j, k[0]) + "] + [" + SingRot(v, i, j, k[1]) + "]| = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1];
                        break;
                    case 2:
                        x = 4 * D - Mathf.Abs(SingRot(x, i, j, k[0])) - Mathf.Abs(SingRot(x, i, j, k[1]));
                        funcseq[i] = "X(" + v + ") = 4*" + D + " - |[" + SingRot(v, i, j, k[0]) + "]| + |[" + SingRot(v, i, j, k[1]) + "]| = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1];
                        break;
                }
                break;
            case 1:
                switch (j)
                {
                    case 0:
                        x = 2 * D - SingRot(x, i, j, k[0]) - SingRot(x, i, j, k[1]);
                        funcseq[i] = "Y(" + v + ") = " + D + "*2 - [" + SingRot(v, i, j, k[0]) + "] - [" + SingRot(v, i, j, k[1]) + "] = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1];
                        break;
                    case 1:
                        x = 2 * vals[0][i] - SingRot(x, i, j, k[0]) - SingRot(x, i, j, k[1]);
                        funcseq[i] = "Y(" + v + ") = " + vals[0][i] + "*2 - [" + SingRot(v, i, j, k[0]) + "] - [" + SingRot(v, i, j, k[1]) + "] = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1];
                        break;
                    case 2:
                        x = 2 * vals[1][i] - SingRot(x, i, j, k[0]) - SingRot(x, i, j, k[1]);
                        funcseq[i] = "Y(" + v + ") = " + vals[1][i] + "*2 - [" + SingRot(v, i, j, k[0]) + "] - [" + SingRot(v, i, j, k[1]) + "] = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1];
                        break;
                }
                break;
            case 2:
                switch (j)
                {
                    case 0:
                        x = SingRot(x, i, j, k[0]) + SingRot(x, i, j, k[1]) - x;
                        funcseq[i] = "Z(" + v + ") = [" + SingRot(v, i, j, k[0]) + "] + [" + SingRot(v, i, j, k[1]) + "] - " + v + " = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1];
                        break;
                    case 1:
                        x = SingRot(x, i, j, k[0]) + SingRot(x, i, j, k[1]) - x - vals[0][i];
                        funcseq[i] = "Z(" + v + ") = [" + SingRot(v, i, j, k[0]) + "] + [" + SingRot(v, i, j, k[1]) + "] - " + v + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1];
                        break;
                    case 2:
                        x = SingRot(x, i, j, k[0]) + SingRot(x, i, j, k[1]) - x - vals[1][i] - vals[0][i];
                        funcseq[i] = "Z(" + v + ") = [" + SingRot(v, i, j, k[0]) + "] + [" + SingRot(v, i, j, k[1]) + "] - " + v + " - " + vals[1][i] + " - " + vals[0][i] + " = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1];
                        break;
                }
                break;
        }
        return x % 365;
    }

    private int TripRot(int x, int i, int j, int[] k)
    {
        int v = x;
        SingRot(v, i, j, k[0]);
        funccatch[0] = funcseq[i];
        SingRot(v, i, j, k[1]);
        funccatch[1] = funcseq[i];
        SingRot(v, i, j, k[2]);
        funccatch[2] = funcseq[i];
        if (k[3] == 0)
        {
            switch (j)
            {
                case 0:
                    x = Mathf.Max(SingRot(x, i, j, k[0]), SingRot(x, i, j, k[1]), SingRot(x, i, j, k[2])) - 2 * D;
                    funcseq[i] = "W(" + v + ") = max([" + SingRot(v, i, j, k[0]) + "], [" + SingRot(v, i, j, k[1]) + "], [" + SingRot(v, i, j, k[2]) + "]) - " + D + "*2 = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1] + "\n[UltraStores #" + moduleID + "]" + funccatch[2];
                    break;
                case 1:
                    x = SingRot(x, i, j, k[0]) + SingRot(x, i, j, k[1]) + SingRot(x, i, j, k[2]) - 3 * x;
                    funcseq[i] = "W(" + v + ") = [" + SingRot(v, i, j, k[0]) + "] + [" + SingRot(v, i, j, k[1]) + "] + [" + SingRot(v, i, j, k[2]) + "] - " + v + "*3 = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1] + "\n[UltraStores #" + moduleID + "]" + funccatch[2];
                    break;
                case 2:
                    x = SingRot(x, i, j, k[0]) + SingRot(x, i, j, k[1]) + SingRot(x, i, j, k[2]) - vals[0][i] - vals[1][i] - x;
                    funcseq[i] = "W(" + v + ") =  [" + SingRot(v, i, j, k[0]) + "] + [" + SingRot(v, i, j, k[1]) + "] + [" + SingRot(v, i, j, k[2]) + "] - " + vals[0][i] + " - " + vals[1][i] + " - " + v + " = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1] + "\n[UltraStores #" + moduleID + "]" + funccatch[2];
                    break;
            }
        }
        else
        {
            switch (j)
            {
                case 0:
                    x = Mathf.Min(SingRot(x, i, j, k[0]), SingRot(x, i, j, k[1]), SingRot(x, i, j, k[2])) + 2 * D;
                    funcseq[i] = "V(" + v + ") = min([" + SingRot(v, i, j, k[0]) + "], [" + SingRot(v, i, j, k[1]) + "], [" + SingRot(v, i, j, k[2]) + "]) + " + D + "*2 = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1] + "\n[UltraStores #" + moduleID + "]" + funccatch[2];
                    break;
                case 1:
                    x = 3 * x - SingRot(x, i, j, k[0]) - SingRot(x, i, j, k[1]) - SingRot(x, i, j, k[2]);
                    funcseq[i] = "V(" + v + ") = " + v + "*3 - [" + SingRot(v, i, j, k[0]) + "] - [" + SingRot(v, i, j, k[1]) + "] - [" + SingRot(v, i, j, k[2]) + "] = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1] + "\n[UltraStores #" + moduleID + "]" + funccatch[2];
                    break;
                case 2:
                    x = vals[0][i] + vals[1][i] + x - SingRot(x, i, j, k[0]) - SingRot(x, i, j, k[1]) - SingRot(x, i, j, k[2]);
                    funcseq[i] = "V(" + v + ") = " + vals[0][i] + " + " + vals[1][i] + " + " + v + " - [" + SingRot(v, i, j, k[0]) + "] - [" + SingRot(v, i, j, k[1]) + "] - [" + SingRot(v, i, j, k[2]) + "] = " + x + " ≈ " + x % 365 + "\n[UltraStores #" + moduleID + "]" + funccatch[0] + "\n[UltraStores #" + moduleID + "]" + funccatch[1] + "\n[UltraStores #" + moduleID + "]" + funccatch[2];
                    break;
            }
        }
        return x % 365;
    }

    private IEnumerator StartCube()
    {
        for (int i = 0; i < 8; i++)
        {
            brends[i].material = buttoncols[8];
        }
        for (int i = 0; i < 64; i++)
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
            for (int j = 0; j < 64; j++)
            {
                ufos[j].transform.localPosition += new Vector3(0.2f*oldpos[j][0] + 0.075f*oldpos[j][5] + 0.05f*oldpos[j][4] + 0.15f*oldpos[j][3], 0.2f*oldpos[j][1] + 0.15f*oldpos[j][5] + 0.1f*oldpos[j][4] + 0.05f*oldpos[j][3], 0.2f*oldpos[j][2] + 0.075f*oldpos[j][5] + 0.15f*oldpos[j][4] + 0.1f*oldpos[j][3]);
                uforends[j].material.color += new Color32((byte)(gen[j][0] / 25), (byte)(gen[j][1] / 25), (byte)(gen[j][2] / 25), 0);
            }
            yield return new WaitForSeconds(0.01f);
        }
        for (int j = 0; j < 64; j++)
        {
            newpos[j] = oldpos[j];
        }
        if (moduleSolved == false)
        {
            subwaiting = false;
            yield return StartCoroutine(RotCycle());
        }
    }

    private IEnumerator RotCycle()
    {
        for (int i = 0; i < (stage + 4) * 25; i++)
        {
            if(i % 25 == 0)
            {
                for(int j = 0; j < 64; j++)
                {
                    oldpos[j] = newpos[j];
                }
                if (subwaiting == true)
                {
                    subwaiting = false;
                    StopAllCoroutines();
                    StartCoroutine(StartSubmission());
                }
                else if (i < (stage + 3) * 25)
                {
                    for(int j = 0; j < 64; j++)
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
                for(int j = 0; j < 64; j++)
                {
                   ufos[j].transform.localPosition += new Vector3(0.2f * (newpos[j][0] - oldpos[j][0]) + 0.075f * (newpos[j][5] - oldpos[j][5]) + 0.05f * (newpos[j][4] - oldpos[j][4]) + 0.15f * (newpos[j][3] - oldpos[j][3]), 0.2f *(newpos[j][1] - oldpos[j][1]) + 0.15f * (newpos[j][5] - oldpos[j][5]) + 0.1f * (newpos[j][4] - oldpos[j][4]) + 0.05f * (newpos[j][3] - oldpos[j][3]), 0.2f * (newpos[j][2] - oldpos[j][2]) + 0.075f * (newpos[j][5] - oldpos[j][5]) + 0.15f * (newpos[j][4] - oldpos[j][4]) + 0.1f * (newpos[j][3] - oldpos[j][3]));
                }
                yield return new WaitForSeconds(0.04f);
            }
        }
    }

    private IEnumerator Recolour()
    {
        int[] rone = new int[3];
        int[][] rtwo = new int[64][];
        if (randrecol == false)
        {
            rone = new int[3] { Random.Range(15, 240), Random.Range(15, 240), Random.Range(15, 240) };
            for (int i = 0; i < 64; i++)
            {
                rtwo[i] = new int[3] { Random.Range(-15, 16), Random.Range(-15, 16), Random.Range(-15, 16) };
            }
        }
        else
        {
            rone = new int[3] { 0, 0, 0 };
            for (int i = 0; i < 64; i++)
            {
                rtwo[i] = new int[3] { Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255) };
            }
        }
        for (int i = 0; i < 50; i++)
        {
            if(i < 25)
            {
                for (int j = 0; j < 64; j++)
                {
                    uforends[j].material.color -= new Color32((byte)(gen[j][0]/25), (byte)(gen[j][1]/25), (byte)(gen[j][2]/25), 0);
                }
            }
            else
            {
                for (int j = 0; j < 64; j++)
                {
                    uforends[j].material.color += new Color32((byte)((rone[0] + rtwo[j][0]) / 25), (byte)((rone[1] + rtwo[j][1]) / 25), (byte)((rone[2] + rtwo[j][2]) / 25), 0);
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
        for(int i = 0; i < 64; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                gen[i][j] = rone[j] + rtwo[i][j];
            }
        }
        recol = false;
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
            for (int j = 0; j < 64; j++)
            {
                ufos[j].transform.localPosition -= new Vector3(0.2f * oldpos[j][0] + 0.075f * oldpos[j][5] + 0.05f * oldpos[j][4] + 0.15f * oldpos[j][3], 0.2f * oldpos[j][1] + 0.15f * oldpos[j][5] + 0.1f * oldpos[j][4] + 0.05f * oldpos[j][3], 0.2f * oldpos[j][2] + 0.075f * oldpos[j][5] + 0.15f * oldpos[j][4] + 0.1f * oldpos[j][3]);
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
        submissable = true;
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
    private readonly string TwitchHelpMessage = @"!{0} start/submit [presses centre button] | !{0} equalise/randomise [changes disc colours] | !{0} RKMCWB [presses coloured buttons; K = black] | !{0} cycle [shows colours of buttons in clockwise order]";
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
        else if (Regex.IsMatch(command, @"^\s*equalise\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            if (submissable == false && subwaiting == false)
            {
                yield return null;
                buttons[0].OnInteract();
            }
            else
            {
                yield return "sendtochaterror Cannot equalise discs in input mode.";
            }
        }
        else if (Regex.IsMatch(command, @"^\s*randomise\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            if (submissable == false && subwaiting == false)
            {
                yield return null;
                buttons[4].OnInteract();
            }
            else
            {
                yield return "sendtochaterror Cannot randomise discs in input mode.";
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
