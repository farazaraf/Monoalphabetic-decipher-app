//200901045- Faraz Ahmad Qureshi - NXSecurity Assignment 01

using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Security.Policy;

namespace WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Controls.Add(OutputText);
            Debug.WriteLine("Calling dictionary file lmao");
            Dictionary.DictionaryLoader();
        }
        string cleanText { get; set; }

        Dictionary<char, int> sortedSingleLetterFrequency = new Dictionary<char, int>(); //separate from the one used in Cipher Class
        int indexLoopVar = 0;



        private void InputText_TextChanged(object sender, EventArgs e)
        {
            Dictionary<char, int> singleLetterFrequency = new Dictionary<char, int>();
            Dictionary<string, int> doubleLetterFrequency = new Dictionary<string, int>();
            Dictionary<string, int> tripleLetterFrequency = new Dictionary<string, int>();

            string input = InputText.Text;
            Debug.WriteLine(input);
            cleanText = Cipher.StringCleaner(input);
            LetterFrequencyList.Text = Cipher.AnalyzeFrequencies(cleanText, singleLetterFrequency);
            DoubleLetterFrequencyList.Text = Cipher.AnalyzeDoubleFrequencies(cleanText, doubleLetterFrequency);
            TripleLetterFrequencyList.Text = Cipher.AnalyzeTripleFrequencies(cleanText, tripleLetterFrequency);
            //this.LetterFrequencyList.Text = Cipher.PrintFrequency(singleLetterFrequency);
            //this.DoubleLetterFrequencyList.Text = Cipher.PrintFrequency(doubleLetterFrequency);
            //this.TripleLetterFrequencyList.Text = Cipher.PrintFrequency(tripleLetterFrequency);

            sortedSingleLetterFrequency = Cipher.SortDictionaryByValuesDescending(singleLetterFrequency);
            //Decoding function lets go



        }

        private void button1_Click(object sender, EventArgs e) //Do the decipher.
        {
            OutputText.Text = Cipher.DecodeWord(cleanText, sortedSingleLetterFrequency).ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //replaces letter A with letter B throughout the output text.
            if (Regex.IsMatch(ReplaceLetter1.Text.ToLower(), "^[A-Za-z]+$") && Regex.IsMatch(ReplaceLetter2.Text.ToLower(), "^[A-Za-z]+$"))
            {
                char toReplace = ReplaceLetter1.Text[0];
                char replaceBy = ReplaceLetter2.Text[0];

                OutputText.Text = OutputText.Text.Replace(toReplace, replaceBy);


            }
            else
            {
                MessageBox.Show("Please enter letters only!");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //reset the output and return it to the original decoded version.
            OutputText.Text = Cipher.DecodeWord(cleanText, sortedSingleLetterFrequency).ToString();
            string[] words = OutputText.Text.Split(' ');
            OutputText.Select(indexLoopVar, words[indexLoopVar].Length);
            OutputText.SelectionBackColor = Color.Blue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] words = OutputText.Text.Split(' ');

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] words = OutputText.Text.Split(' ');
            if (indexLoopVar < words.Length)
            {
                indexLoopVar += 1;
                OutputText.Select(0, words[indexLoopVar].Length);
                OutputText.SelectionBackColor = Color.Blue;
            }
        }

        private void OutputText_MouseClick(object sender, MouseEventArgs e)
        {
            int clickedCharIndex = OutputText.GetCharIndexFromPosition(e.Location);
            int startIndex = FindWordStartIndex(clickedCharIndex);
            int endIndex = FindWordEndIndex(clickedCharIndex);

            if (startIndex != -1 && endIndex != -1)
            {
                OutputText.SelectionStart = startIndex;
                OutputText.SelectionLength = endIndex - startIndex + 1;
                Debug.WriteLine(OutputText.SelectedText);
                DictionaryInput.Text = OutputText.SelectedText;
                var commonWordList = Dictionary.DictionaryPattern(OutputText.SelectedText);
                Debug.WriteLine(commonWordList);
                string dictString = "";
                foreach (string str in commonWordList)
                {
                    dictString += "\n" + str;
                }
                DictionaryList.Text = dictString;
            }
        }

        private int FindWordStartIndex(int index)
        {
            string text = OutputText.Text;
            if (index >= 0 && index < text.Length)
            {
                int startIndex = text.LastIndexOfAny(new[] { ' ', '\t', '\n' }, index) + 1;
                return startIndex >= 0 ? startIndex : 0;
            }
            return -1;
        }

        private int FindWordEndIndex(int index)
        {
            string text = OutputText.Text;
            if (index >= 0 && index < text.Length)
            {
                int endIndex = text.IndexOfAny(new[] { ' ', '\t', '\n' }, index);
                return endIndex >= 0 ? endIndex - 1 : text.Length - 1;
            }
            return -1;
        }

        public static bool isHiddenFreq = false;
        private void LoadLetterFrequencies_CheckedChanged(object sender, EventArgs e)
        {
            if (!isHiddenFreq)
            {
                LetterFrequencyList.Hide();
                DoubleLetterFrequencyList.Hide();
                TripleLetterFrequencyList.Hide();
                isHiddenFreq = true;
            }
            else
            {
                LetterFrequencyList.Show();
                DoubleLetterFrequencyList.Show();
                TripleLetterFrequencyList.Show();
                isHiddenFreq = false;
            }
        }
    }
}

public static class Dictionary
{
    private static string[] commonWordList = DictionaryLoader();

    public static List<string> DictionaryPattern(string msgWord)
    {
        var matchString = new List<string>();
        foreach(string word in commonWordList)
        {
            if(word.Length == msgWord.Length)
            {
                matchString.Add(word);
            }
        }
        return matchString;
        //we take the input word/string of dictionary
        //check its length
        //check the length of characters in our dictionary
        //print outputs accordingly.
    }

    public static string[] DictionaryLoader()
    {
        //load the dictionary file
        try
        {
            // Specify the path to the file within your project folder
            //string filePath = "..\\..\\..\\..\\commonwords.txt"; // Update with your actual file name

            // Read the entire contents of the file into a string
            string fileContent = "pakistan\r\ncomputing\r\ninternational\r\nterrorist\r\nhacking\r\nnadra\r\nhacker\r\nislamabad\r\nthe\r\nof\r\nto\r\nand\r\na\r\nin\r\nis\r\nit\r\nyou\r\nthat\r\nhe\r\nwas\r\nfor\r\non\r\nare\r\nwith\r\nas\r\nI\r\nhis\r\nthey\r\nbe\r\nat\r\none\r\nhave\r\nthis\r\nfrom\r\nor\r\nhad\r\nby\r\nword\r\nbut\r\nwhat\r\nsome\r\nwe\r\ncan\r\nout\r\nother\r\nwere\r\nall\r\nthere\r\nwhen\r\nup\r\nuse\r\nyour\r\nhow\r\nsaid\r\nan\r\neach\r\nshe\r\nwhich\r\ndo\r\ntheir\r\ntime\r\nif\r\nwill\r\nway\r\nabout\r\nmany\r\nthen\r\nthem\r\nwrite\r\nwould\r\nlike\r\nso\r\nthese\r\nher\r\nlong\r\nmake\r\nthing\r\nsee\r\nhim\r\ntwo\r\nhas\r\nlook\r\nmore\r\nday\r\ncould\r\ngo\r\ncome\r\ndid\r\nnumber\r\nsound\r\nno\r\nmost\r\npeople\r\nmy\r\nover\r\nknow\r\nwater\r\nthan\r\ncall\r\nfirst\r\nwho\r\nmay\r\ndown\r\nside\r\nbeen\r\nnow\r\nfind\r\nany\r\nnew\r\nwork\r\npart\r\ntake\r\nget\r\nplace\r\nmade\r\nlive\r\nwhere\r\nafter\r\nback\r\nlittle\r\nonly\r\nround\r\nman\r\nyear\r\ncame\r\nshow\r\nevery\r\ngood\r\nme\r\ngive\r\nour\r\nunder\r\nname\r\nvery\r\nthrough\r\njust\r\nform\r\nsentence\r\ngreat\r\nthink\r\nsay\r\nhelp\r\nlow\r\nline\r\ndiffer\r\nturn\r\ncause\r\nmuch\r\nmean\r\nbefore\r\nmove\r\nright\r\nboy\r\nold\r\ntoo\r\nsame\r\ntell\r\ndoes\r\nset\r\nthree\r\nwant\r\nair\r\nwell\r\nalso\r\nplay\r\nsmall\r\nend\r\nput\r\nhome\r\nread\r\nhand\r\nport\r\nlarge\r\nspell\r\nadd\r\neven\r\nland\r\nhere\r\nmust\r\nbig\r\nhigh\r\nsuch\r\nfollow\r\nact\r\nwhy\r\nask\r\nmen\r\nchange\r\nwent\r\nlight\r\nkind\r\noff\r\nneed\r\nhouse\r\npicture\r\ntry\r\nus\r\nagain\r\nanimal\r\npoint\r\nmother\r\nworld\r\nnear\r\nbuild\r\nself\r\nearth\r\nfather\r\nhead\r\nstand\r\nown\r\npage\r\nshould\r\ncountry\r\nfound\r\nanswer\r\nschool\r\ngrow\r\nstudy\r\nstill\r\nlearn\r\nplant\r\ncover\r\nfood\r\nsun\r\nfour\r\nbetween\r\nstate\r\nkeep\r\neye\r\nnever\r\nlast\r\nlet\r\nthought\r\ncity\r\ntree\r\ncross\r\nfarm\r\nhard\r\nstart\r\nmight\r\nstory\r\nsaw\r\nfar\r\nsea\r\ndraw\r\nleft\r\nlate\r\nrun\r\ndon't\r\nwhile\r\npress\r\nclose\r\nnight\r\nreal\r\nlife\r\nfew\r\nnorth\r\nopen\r\nseem\r\ntogether\r\nnext\r\nwhite\r\nchildren\r\nbegin\r\ngot\r\nwalk\r\nexample\r\nease\r\npaper\r\ngroup\r\nalways\r\nmusic\r\nthose\r\nboth\r\nmark\r\noften\r\nletter\r\nuntil\r\nmile\r\nriver\r\ncar\r\nfeet\r\ncare\r\nsecond\r\nbook\r\ncarry\r\ntook\r\nscience\r\neat\r\nroom\r\nfriend\r\nbegan\r\nidea\r\nfish\r\nmountain\r\nstop\r\nonce\r\nbase\r\nhear\r\nhorse\r\ncut\r\nsure\r\nwatch\r\ncolor\r\nface\r\nwood\r\nmain\r\nenough\r\nplain\r\ngirl\r\nusual\r\nyoung\r\nready\r\nabove\r\never\r\nred\r\nlist\r\nthough\r\nfeel\r\ntalk\r\nbird\r\nsoon\r\nbody\r\ndog\r\nfamily\r\ndirect\r\npose\r\nleave\r\nsong\r\nmeasure\r\ndoor\r\nproduct\r\nblack\r\nshort\r\nnumeral\r\nclass\r\nwind\r\nquestion\r\nhappen\r\ncomplete\r\nship\r\narea\r\nhalf\r\nrock\r\norder\r\nfire\r\nsouth\r\nproblem\r\npiece\r\ntold\r\nknew\r\npass\r\nsince\r\ntop\r\nwhole\r\nking\r\nspace\r\nheard\r\nbest\r\nhour\r\nbetter\r\ntrue .\r\nduring\r\nhundred\r\nfive\r\nremember\r\nstep\r\nearly\r\nhold\r\nwest\r\nground\r\ninterest\r\nreach\r\nfast\r\nverb\r\nsing\r\nlisten\r\nsix\r\ntable\r\ntravel\r\nless\r\nmorning\r\nten\r\nsimple\r\nseveral\r\nvowel\r\ntoward\r\nwar\r\nlay\r\nagainst\r\npattern\r\nslow\r\ncenter\r\nlove\r\nperson\r\nmoney\r\nserve\r\nappear\r\nroad\r\nmap\r\nrain\r\nrule\r\ngovern\r\npull\r\ncold\r\nnotice\r\nvoice\r\nunit\r\npower\r\ntown\r\nfine\r\ncertain\r\nfly\r\nfall\r\nlead\r\ncry\r\ndark\r\nmachine\r\nnote\r\nwait\r\nplan\r\nfigure\r\nstar\r\nbox\r\nnoun\r\nfield\r\nrest\r\ncorrect\r\nable\r\npound\r\ndone\r\nbeauty\r\ndrive\r\nstood\r\ncontain\r\nfront\r\nteach\r\nweek\r\nfinal\r\ngave\r\ngreen\r\noh\r\nquick\r\ndevelop\r\nocean\r\nwarm\r\nfree\r\nminute\r\nstrong\r\nspecial\r\nmind\r\nbehind\r\nclear\r\ntail\r\nproduce\r\nfact\r\nstreet\r\ninch\r\nmultiply\r\nnothing\r\ncourse\r\nstay\r\nwheel\r\nfull\r\nforce\r\nblue\r\nobject\r\ndecide\r\nsurface\r\ndeep\r\nmoon\r\nisland\r\nfoot\r\nsystem\r\nbusy\r\ntest\r\nrecord\r\nboat\r\ncommon\r\ngold\r\npossible\r\nplane\r\nstead\r\ndry\r\nwonder\r\nlaugh\r\nthousand\r\nago\r\nran\r\ncheck\r\ngame\r\nshape\r\nequate\r\nhot\r\nmiss\r\nbrought\r\nheat\r\nsnow\r\ntire\r\nbring\r\nyes\r\ndistant\r\nfill\r\neast\r\npaint\r\nlanguage\r\namong\r\ngrand\r\nball\r\nyet\r\nwave\r\ndrop\r\nheart\r\nam\r\npresent\r\nheavy\r\ndance\r\nengine\r\nposition\r\narm\r\nwide\r\nsail\r\nmaterial\r\nsize\r\nvary\r\nsettle\r\nspeak\r\nweight\r\ngeneral\r\nice\r\nmatter\r\ncircle\r\npair\r\ninclude\r\ndivide\r\nsyllable\r\nfelt\r\nperhaps\r\npick\r\nsudden\r\ncount\r\nsquare\r\nreason\r\nlength\r\nrepresent\r\nart\r\nsubject\r\nregion\r\nenergy\r\nhunt\r\nprobable\r\nbed\r\nbrother\r\negg\r\nride\r\ncell\r\nbelieve\r\nfraction\r\nforest\r\nsit\r\nrace\r\nwindow\r\nstore\r\nsummer\r\ntrain\r\nsleep\r\nprove\r\nlone\r\nleg\r\nexercise\r\nwall\r\ncatch\r\nmount\r\nwish\r\nsky\r\nboard\r\njoy\r\nwinter\r\nsat\r\nwritten\r\nwild\r\ninstrument\r\nkept\r\nglass\r\ngrass\r\ncow\r\njob\r\nedge\r\nsign\r\nvisit\r\npast\r\nsoft\r\nfun\r\nbright\r\ngas\r\nweather\r\nmonth\r\nmillion\r\nbear\r\nfinish\r\nhappy\r\nhope\r\nflower\r\nclothe\r\nstrange\r\ngone\r\njump\r\nbaby\r\neight\r\nvillage\r\nmeet\r\nroot\r\nbuy\r\nraise\r\nsolve\r\nmetal\r\nwhether\r\npush\r\nseven\r\nparagraph\r\nthird\r\nshall\r\nheld\r\nhair\r\ndescribe\r\ncook\r\nfloor\r\neither\r\nresult\r\nburn\r\nhill\r\nsafe\r\ncat\r\ncentury\r\nconsider\r\ntype\r\nlaw\r\nbit\r\ncoast\r\ncopy\r\nphrase\r\nsilent\r\ntall\r\nsand\r\nsoil\r\nroll\r\ntemperature\r\nfinger\r\nindustry\r\nvalue\r\nfight\r\nlie\r\nbeat\r\nexcite\r\nnatural\r\nview\r\nsense\r\near\r\nelse\r\nquite\r\nbroke\r\ncase\r\nmiddle\r\nkill\r\nson\r\nlake\r\nmoment\r\nscale\r\nloud\r\nspring\r\nobserve\r\nchild\r\nstraight\r\nconsonant\r\nnation\r\ndictionary\r\nmilk\r\nspeed\r\nmethod\r\norgan\r\npay\r\nage\r\nsection\r\ndress\r\ncloud\r\nsurprise\r\nquiet\r\nstone\r\ntiny\r\nclimb\r\ncool\r\ndesign\r\npoor\r\nlot\r\nexperiment\r\nbottom\r\nkey\r\niron\r\nsingle\r\nstick\r\nflat\r\ntwenty\r\nskin\r\nsmile\r\ncrease\r\nhole\r\ntrade\r\nmelody\r\ntrip\r\noffice\r\nreceive\r\nrow\r\nmouth\r\nexact\r\nsymbol\r\ndie\r\nleast\r\ntrouble\r\nshout\r\nexcept\r\nwrote\r\nseed\r\ntone\r\njoin\r\nsuggest\r\nclean\r\nbreak\r\nlady\r\nyard\r\nrise\r\nbad\r\nblow\r\noil\r\nblood\r\ntouch\r\ngrew\r\ncent\r\nmix\r\nteam\r\nwire\r\ncost\r\nlost\r\nbrown\r\nwear\r\ngarden\r\nequal\r\nsent\r\nchoose\r\nfell\r\nfit\r\nflow\r\nfair\r\nbank\r\ncollect\r\nsave\r\ncontrol\r\ndecimal\r\ngentle\r\nwoman\r\ncaptain\r\npractice\r\nseparate\r\ndifficult\r\ndoctor\r\nplease\r\nprotect\r\nnoon\r\nwhose\r\nlocate\r\nring\r\ncharacter\r\ninsect\r\ncaught\r\nperiod\r\nindicate\r\nradio\r\nspoke\r\natom\r\nhuman\r\nhistory\r\neffect\r\nelectric\r\nexpect\r\ncrop\r\nmodern\r\nelement\r\nhit\r\nstudent\r\ncorner\r\nparty\r\nsupply\r\nbone\r\nrail\r\nimagine\r\nprovide\r\nagree\r\nthus\r\ncapital\r\nwon't\r\nchair\r\ndanger\r\nfruit\r\nrich\r\nthick\r\nsoldier\r\nprocess\r\noperate\r\nguess\r\nnecessary\r\nsharp\r\nwing\r\ncreate\r\nneighbor\r\nwash\r\nbat\r\nrather\r\ncrowd\r\ncorn\r\ncompare\r\npoem\r\nstring\r\nbell\r\ndepend\r\nmeat\r\nrub\r\ntube\r\nfamous\r\ndollar\r\nstream\r\nfear\r\nsight\r\nthin\r\ntriangle\r\nplanet\r\nhurry\r\nchief\r\ncolony\r\nclock\r\nmine\r\ntie\r\nenter\r\nmajor\r\nfresh\r\nsearch\r\nsend\r\nyellow\r\ngun\r\nallow\r\nprint\r\ndead\r\nspot\r\ndesert\r\nsuit\r\ncurrent\r\nlift\r\nrose\r\ncontinue\r\nblock\r\nchart\r\nhat\r\nsell\r\nsuccess\r\ncompany\r\nsubtract\r\nevent\r\nparticular\r\ndeal\r\nswim\r\nterm\r\nopposite\r\nwife\r\nshoe\r\nshoulder\r\nspread\r\narrange\r\ncamp\r\ninvent\r\ncotton\r\nborn\r\ndetermine\r\nquart\r\nnine\r\ntruck\r\nnoise\r\nlevel\r\nchance\r\ngather\r\nshop\r\nstretch\r\nthrow\r\nshine\r\nproperty\r\ncolumn\r\nmolecule\r\nselect\r\nwrong\r\ngray\r\nrepeat\r\nrequire\r\nbroad\r\nprepare\r\nsalt\r\nnose\r\nplural\r\nanger\r\nclaim\r\ncontinent\r\noxygen\r\nsugar\r\ndeath\r\npretty\r\nskill\r\nwomen\r\nseason\r\nsolution\r\nmagnet\r\nsilver\r\nthank\r\nbranch\r\nmatch\r\nsuffix\r\nespecially\r\nfig\r\nafraid\r\nhuge\r\nsister\r\nsteel\r\ndiscuss\r\nforward\r\nsimilar\r\nguide\r\nexperience\r\nscore\r\napple\r\nbought\r\nled\r\npitch\r\ncoat\r\nmass\r\ncard\r\nband\r\nrope\r\nslip\r\nwin\r\ndream\r\nevening\r\ncondition\r\nfeed\r\ntool\r\ntotal\r\nbasic\r\nsmell\r\nvalley\r\nnor\r\ndouble\r\nseat\r\narrive\r\nmaster\r\ntrack\r\nparent\r\nshore\r\ndivision\r\nsheet\r\nsubstance\r\nfavor\r\nconnect\r\npost\r\nspend\r\nchord\r\nfat\r\nglad\r\noriginal\r\nshare\r\nstation\r\ndad\r\nbread\r\ncharge\r\nproper\r\nbar\r\noffer\r\nsegment\r\nslave\r\nduck\r\ninstant\r\nmarket\r\ndegree\r\npopulate\r\nchick\r\ndear\r\nenemy\r\nreply\r\ndrink\r\noccur\r\nsupport\r\nspeech\r\nnature\r\nrange\r\nsteam\r\nmotion\r\npath\r\nliquid\r\nlog\r\nmeant\r\nquotient\r\nteeth\r\nshell\r\nneck\r\n";
            string[] commonWords = fileContent.Split("\r\n");
            // Display the content to the console
            Debug.WriteLine("File Content:");
            foreach(string s in commonWords)
            Debug.WriteLine(s);
            return commonWords;
            
        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur during file reading
            Debug.WriteLine($"Error@dictionaryloader!: {ex.Message}");
            return [""];
        }
    }
}


    public static class Cipher
    {
        public static String StringCleaner(string input)
        {
            var cleanString = Regex.Replace(input, "[^a-z\\s]", "");
            Debug.WriteLine(cleanString);
            return cleanString;
        }

        public static StringBuilder DecodeWord(string input, Dictionary<char,int> letterFrequency)
        {
            StringBuilder replacedWord = new StringBuilder();
            string[] words = TokenizeWords(input);
            var FrequencyTable = CreatingDictionaryItems(letterFrequency);
            foreach (var word in words)
            {
                foreach(char c in word)
                {
                    if (FrequencyTable.TryGetValue(c, out var frequency))
                        replacedWord.Append(frequency);
                    else
                    {
                        // Keep the original letter if not found in the dictionary    
                    replacedWord.Append(c);
                    }
                    //compare c with our dictionary thingy
                    //replace c with the value that it corresponds to
                }
            replacedWord.Append(' ');
            }
            Debug.WriteLine("this is the replaced word: " + replacedWord);
        return replacedWord;
        }

        private static Dictionary<char,char> CreatingDictionaryItems(Dictionary<char, int> letterFrequencyDict)
        {

        char[] englishFrequency = { 'e', 't', 'a', 's', 'i', 'n', 'r', 'o', 'h', 'l', 'd', 'u', 'c', 'm', 'w', 'g', 'y', 'p', 'f', 'b', 'v', 'k', 'j', 'x', 'z', 'q' };
        var FrequencyTable = new Dictionary<char, char>();
            int i = 0;
                foreach(var letterFrequency in letterFrequencyDict)
            {
                FrequencyTable.Add(letterFrequency.Key, englishFrequency[i]);
                i++;

            }
            return FrequencyTable;

        }

        public static string AnalyzeFrequencies(string inputText,Dictionary<char,int> dict)
        {
            string[] words = TokenizeWords(inputText);
            foreach (string word in words)
            {
                // Single Letter Frequency Analysis
                foreach (char character in word)
                {
                    if (Char.IsLetter(character) == true)
                        UpdateFrequency(dict, character);
                }
                
            }
            var sortedSingleLetterFrequency = SortDictionaryByValuesDescending(dict);
            return PrintFrequency(sortedSingleLetterFrequency);
        }

        public static string AnalyzeDoubleFrequencies(string inputText, Dictionary<string, int> dict)
        {
            string[] words = TokenizeWords(inputText);
            foreach (string word in words)
            {
                // Process 2/3 Letter Frequency only on individual 2/3 letter words
                if (word.Length == 2)
                {
                    UpdateFrequency(dict, word);
                }
            }
            return PrintFrequency(dict); //before u do the double and triple letter frequencies, just showcase the result as output in form
            //return dict;
        }

        public static string AnalyzeTripleFrequencies(string inputText, Dictionary<string, int> dict)
        {
            string[] words = TokenizeWords(inputText);
            foreach (string word in words)
            {
                // Process 2/3 Letter Frequency only on individual 2/3 letter words
                if (word.Length == 3)
                {
                    UpdateFrequency(dict, word);
                }
            }
            return PrintFrequency(dict); //before u do the double and triple letter frequencies, just showcase the result as output in form
            //return dict;
        }

        private static string[] TokenizeWords(string inputText)
        {
            // Remove punctuation and split into words
            string[] words = Regex.Split(inputText, @"\W+");

            // Filter out empty strings
            words = Array.FindAll(words, s => !string.IsNullOrEmpty(s));

            return words;
        }

        public static Dictionary<TKey, TValue> SortDictionaryByValuesDescending<TKey, TValue>(Dictionary<TKey, TValue> inputDict)
        {
            var sortedList = inputDict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return sortedList;
        }

        private static void UpdateFrequency<T>(Dictionary<T, int> frequencyDictionary, T key)
        {
            if (frequencyDictionary.ContainsKey(key))
            {
                frequencyDictionary[key]++;
            }
            else
            {
                frequencyDictionary[key] = 1;
            }
        }

        public static string PrintFrequency<T>(Dictionary<T, int> frequencyDictionary)
        {
            string output = "";
            foreach (var pair in frequencyDictionary)
            {
                Debug.WriteLine($"{pair.Key}: {pair.Value}");
                output += $"{pair.Key}: {pair.Value}\t";
            }
            return output;
        }
    }
