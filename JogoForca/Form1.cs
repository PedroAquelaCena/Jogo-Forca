using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace JogoForca
{
    public partial class Form1 : Form
    {
        //variaveis globais à classe
        string[] palavras; //arrayspara guardar as palavras do dicionário
        string palavra;
        char[] palEscondida; //array de caracters para a palvara que vai adivinhar
        bool acertou;
        string grau = "facil";
        short nImg;
        bool soundON = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniciarJogo();
        }

        private void IniciarJogo()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            buttonStart.Visible = false;
            buttonSom.Visible = false;
            Dificuldade.Visible = false;
            buttonDificuldade.Visible = true;
            groupBoxTeclado.Visible = false;
            labelPalavraFinal.Visible = false;
            labelLetras.Visible = false;
            pictureboxForca.Visible = false;
            pictureBoxPerdeu.Visible = false;
            pictureBoxGanhou.Visible = false;
            Dificuldade.Visible = false;
            pictureBox1.Visible = true;
            buttonReset.Visible = false;
            acertou = false;
            nImg = 0;
            ApresentarImg(nImg);
        }

        private void ApresentarImg(short nI)
        {
            try
            {
                if (nI == 0)
                    pictureboxForca.Image = Properties.Resources.forca0;

                else if (nI == 1)
                    pictureboxForca.Image = Properties.Resources.forca1;

                else if (nI == 2)
                    pictureboxForca.Image = Properties.Resources.forca2;

                else if (nI == 3)
                    pictureboxForca.Image = Properties.Resources.forca3;

                else if (nI == 4)
                    pictureboxForca.Image = Properties.Resources.forca4;

                else if (nI == 5)
                    pictureboxForca.Image = Properties.Resources.forca5;

                else if (nI == 6)
                    pictureboxForca.Image = Properties.Resources.forca6;

                else if (nI == 7)
                    pictureboxForca.Image = Properties.Resources.forca7;

                else if (nI == 8)
                    pictureboxForca.Image = Properties.Resources.forca8;

                else if (nI == 9)
                    pictureboxForca.Image = Properties.Resources.forcaMorto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.Message);
            }
        }

        private void IniciarDicionario()
        {
            palavras = new string[40];

            try
            {
                if (grau == "facil")
                {
                    palavras[0] = "África do Sul";
                    palavras[1] = "Angola";
                    palavras[2] = "Argélia";
                    palavras[3] = "Benin";
                    palavras[4] = "Cuba";
                    palavras[5] = "Equador";
                    palavras[6] = "Paraguai";
                    palavras[7] = "Nicarágua";
                    palavras[8] = "Suriname";
                    palavras[9] = "Santa Lúcia";
                    palavras[10] = "Bangladesh";
                    palavras[11] = "Laos";
                    palavras[12] = "Myanmar";
                    palavras[13] = "Japão";
                    palavras[14] = "Quirguistão";
                    palavras[15] = "Dinamarca";
                    palavras[16] = "San Marino";
                    palavras[17] = "Mônaco";
                    palavras[18] = "Grécia";
                    palavras[19] = "Chipre";
                    palavras[20] = "Andorra";
                    palavras[21] = "Alemanha";
                    palavras[22] = "Palau";
                    palavras[23] = "Samoa";
                    palavras[24] = "Fiji";
                    palavras[25] = "Nova Zelândia";
                    palavras[26] = "Brasil";
                    palavras[27] = "China";
                    palavras[28] = "Canadá";
                    palavras[29] = "Rússia";
                    palavras[30] = "Índia";
                    palavras[31] = "Vaticano";
                    palavras[32] = "Espanha";
                    palavras[33] = "México";
                    palavras[34] = "Bahamas";
                    palavras[35] = "Chade";
                    palavras[36] = "Colômbia";
                    palavras[37] = "Crimeia";
                    palavras[38] = "Egito";
                    palavras[39] = "Itália";
                }
                else if (grau == "medio")
                {
                    palavras[0] = "The Legend of Zelda";
                    palavras[1] = "Leo Gordo";
                    palavras[2] = "Super Mario World";
                    palavras[3] = "Grand Theft Auto V";
                    palavras[4] = "Minecraft";
                    palavras[5] = "League of Legends";
                    palavras[6] = "Super Mario Bros";
                    palavras[7] = "Dark Souls";
                    palavras[8] = "The Witcher";
                    palavras[9] = "Street Fighter";
                    palavras[10] = "World of Warcraft";
                    palavras[11] = "Fortnite";
                    palavras[12] = "PUBG";
                    palavras[13] = "The Elder Scrolls";
                    palavras[14] = "The Last of Us";
                    palavras[15] = "Red Dead Redemption";
                    palavras[16] = "God of War";
                    palavras[17] = "Metal Gear Solid";
                    palavras[18] = "Final Fantasy VII";
                    palavras[19] = "Horizon Zero Dawn";
                    palavras[20] = "Grand Theft Auto San Andreas";
                    palavras[21] = "Counter-Strike";
                    palavras[22] = "Space Invaders";
                    palavras[23] = "Doom";
                    palavras[24] = "Assassins Creed";
                    palavras[25] = "Cuphead";
                    palavras[26] = "Gears of War";
                    palavras[27] = "Goldeneye";
                    palavras[28] = "Dota";
                    palavras[29] = "Warcraft Reign of Chaos";
                    palavras[30] = "Star Fox";
                    palavras[31] = "Super Smash Bros";
                    palavras[32] = "Cities Skyline";
                    palavras[33] = "Unreal Tournament";
                    palavras[34] = "Civilization IV";
                    palavras[35] = "Monster Hunter";
                    palavras[36] = "Undertale";
                    palavras[37] = "Super Mario Odyssey";
                    palavras[38] = "Tetris";
                    palavras[39] = "Mega Man";
                }
                else if (grau == "dificil")
                {
                    palavras[0] = "Hunter x Hunter";
                    palavras[1] = "No Game No Life";
                    palavras[2] = "One Punch Man";
                    palavras[3] = "Shokugeki no Souma";
                    palavras[4] = "Hataraku Maou sama";
                    palavras[5] = "Death Note";
                    palavras[6] = "Boku no Hero Academia";
                    palavras[7] = "Magi";
                    palavras[8] = "Owari no Seraph";
                    palavras[9] = "World Trigger";
                    palavras[10] = "Assassination Classroom";
                    palavras[11] = "The Seven Deadly Sins";
                    palavras[12] = "Big Lucas";
                    palavras[13] = "Naruto";
                    palavras[14] = "Tensei Shitara";
                    palavras[15] = "Mob Psycho";
                    palavras[16] = "Dungeon ni Deai wo Motomeru no wa Machigatteiru Darou ka";
                    palavras[17] = "Bungou Stray Dogs";
                    palavras[18] = "Blood Lad";
                    palavras[19] = "Trinity Seven";
                    palavras[20] = "Rakudai Kishi no Cavalry";
                    palavras[21] = "Parasyte";
                    palavras[22] = "Thais Carla";
                    palavras[23] = "Sakamoto desu ga";
                    palavras[24] = "Soul Eater";
                    palavras[25] = "Mahouka Koukou no Rettousei";
                    palavras[26] = "Os Cavaleiros do Zodíaco";
                    palavras[27] = "Dragon Ball Super";
                    palavras[28] = "One Piece";
                    palavras[29] = "Code Geass";
                    palavras[30] = "Charlotte";
                    palavras[31] = "Death Parade";
                    palavras[32] = "Sword Art Online";
                    palavras[33] = "Gintama";
                    palavras[34] = "Haikyuu";
                    palavras[35] = "Demon Slayer";
                    palavras[36] = "Jujutsu Kaisen";
                    palavras[37] = "Tokyo Revengers";
                    palavras[38] = "Overlord";
                    palavras[39] = "Black Clover";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no carregamento do dicionário: " + ex.Message);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            IniciarDicionario();
            buttonDificuldade.Visible = true;
            Dificuldade.Visible = true;
            buttonSom.Visible = true;
            buttonStart.Visible = false;
            Dificuldade.Visible = false;
            buttonDificuldade.Visible = false;
            pictureboxForca.Visible = true;
            pictureBox1.Visible = false;
            buttonReset.Visible = true;

            MostrarLetras();
            string word = SelecionarPalavra();
            ApresentarPalavra(word);
            SomInicial();
        }

        private void MostrarLetras()
        {
            groupBoxTeclado.Visible = true;
            labelLetras.Visible = true;
        }

        private string SelecionarPalavra()
        {
            Random rnd = new Random();

            int n = rnd.Next(30);

            return (palavras[n]);
        }

        private void ApresentarPalavra(string s)
        {
            int t = s.Length;

            palEscondida = new char[t];

            for (int i = 0; i < t; i++)
                palEscondida[i] = '-';

            string sf = new string(palEscondida);
            labelLetras.Text = sf;

            palavra = s;
        }

        private void SomInicial()
        {
            Stream st = Properties.Resources.Beat;

            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(st);

            sp.PlayLooping();
            buttonSom.BackgroundImage = Properties.Resources.iconVolume;
            soundON = true;
        }

        private void buttonSom_Click(object sender, EventArgs e)
        {
            Stream st = Properties.Resources.Beat;

            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(st);

            if (soundON)
            {
                sp.Stop();
                soundON = false;
                buttonSom.BackgroundImage = Properties.Resources.somoff;
            }

            else
            {
                sp.PlayLooping();
                soundON = true;
                buttonSom.BackgroundImage = Properties.Resources.iconVolume;
            }
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            buttonA.Visible = false;
            acertou = false;
            VerificarLetra('A');
            VerificarLetra('a');
            VerificarLetra('á');
            VerificarLetra('à');
            VerificarLetra('ã');
            VerificarLetra('â');
            VerificarLetra('Á');
            VerificarLetra('À');
            VerificarLetra('Ã');
            VerificarLetra('Â');

            AtualizarJogo();
        }

        private void VerificarLetra(char c)
        {
            char[] pal = palavra.ToCharArray(); //palavra a adivinhar (em caracteres)

            for (int i = 0; i < palavra.Length; i++)
            {
                if (pal[i] == c)
                {
                    acertou = true;
                    palEscondida[i] = c;
                }
            }
            string s = new string(palEscondida);
            labelLetras.Text = s;
        }

        private void AtualizarJogo()
        {
            if (!acertou)  //<=> acertou == false
            {
                nImg++;
                ApresentarImg(nImg);

                if (nImg == 9)
                {
                    FimJogo(false);
                }
            }
            VerificarGanhou();
        }

        private void VerificarGanhou()
        {
            string s = new string(palEscondida);

            if (string.Compare(s, palavra) == 0)
            {
                FimJogo(true);

                pictureBoxPerdeu.Visible = false;
            }
        }

        private void FimJogo(bool gh)
        {
            Stream st = Properties.Resources.Beat;

            Stream mf = Properties.Resources.MusicaFinal;
            System.Media.SoundPlayer mff = new System.Media.SoundPlayer(mf);

            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(st);

            Stream sr = Properties.Resources.Risada;

            System.Media.SoundPlayer sw = new System.Media.SoundPlayer(sr);

            sp.Stop();
            labelPalavraFinal.Visible = true;
            soundON = false;
            labelPalavraFinal.Text = ("A palavra era "+palavra);
            buttonSom.Visible = false;

            groupBoxTeclado.Visible = false;
            buttonReset.Visible = true;
            Dificuldade.Visible = false;
            pictureboxForca.Visible = false;
            labelLetras.Visible = false;
            pictureBoxPerdeu.Visible = true;
            pictureBox1.Visible = true;
            buttonDificuldade.Visible = false;

            if (gh)
            {
                mff.Play();
                pictureBoxGanhou.Visible = true;
            }

            else
            {
                sw.PlayLooping();
                pictureBoxPerdeu.Visible = true;
            }
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            buttonB.Visible = false;
            acertou = false;
            VerificarLetra('B');
            VerificarLetra('b');

            AtualizarJogo();
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            buttonC.Visible = false;
            acertou = false;
            VerificarLetra('C');
            VerificarLetra('c');
            VerificarLetra('ç');

            AtualizarJogo();
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            buttonD.Visible = false;
            acertou = false;
            VerificarLetra('D');
            VerificarLetra('d');

            AtualizarJogo();
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            buttonE.Visible = false;
            acertou = false;
            VerificarLetra('E');
            VerificarLetra('É');
            VerificarLetra('È');
            VerificarLetra('Ê');
            VerificarLetra('e');
            VerificarLetra('é');
            VerificarLetra('è');
            VerificarLetra('ê');

            AtualizarJogo();
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            buttonF.Visible = false;
            acertou = false;
            VerificarLetra('F');
            VerificarLetra('f');

            AtualizarJogo();
        }

        private void buttonG_Click(object sender, EventArgs e)
        {
            buttonG.Visible = false;
            acertou = false;
            VerificarLetra('G');
            VerificarLetra('g');

            AtualizarJogo();
        }

        private void buttonH_Click(object sender, EventArgs e)
        {
            buttonH.Visible = false;
            acertou = false;
            VerificarLetra('H');
            VerificarLetra('h');

            AtualizarJogo();
        }

        private void buttonI_Click(object sender, EventArgs e)
        {
            buttonI.Visible = false;
            acertou = false;
            VerificarLetra('I');
            VerificarLetra('Í');
            VerificarLetra('i');
            VerificarLetra('í');

            AtualizarJogo();
        }

        private void buttonJ_Click(object sender, EventArgs e)
        {
            buttonJ.Visible = false;
            acertou = false;
            VerificarLetra('J');
            VerificarLetra('j');

            AtualizarJogo();
        }

        private void buttonK_Click(object sender, EventArgs e)
        {
            buttonK.Visible = false;
            acertou = false;
            VerificarLetra('K');
            VerificarLetra('k');

            AtualizarJogo();
        }

        private void buttonL_Click(object sender, EventArgs e)
        {
            buttonL.Visible = false;
            acertou = false;
            VerificarLetra('L');
            VerificarLetra('l');

            AtualizarJogo();
        }

        private void buttonM_Click(object sender, EventArgs e)
        {
            buttonM.Visible = false;
            acertou = false;
            VerificarLetra('M');
            VerificarLetra('m');

            AtualizarJogo();
        }

        private void buttonN_Click(object sender, EventArgs e)
        {
            buttonN.Visible = false;
            acertou = false;
            VerificarLetra('N');
            VerificarLetra('n');

            AtualizarJogo();
        }

        private void buttonO_Click(object sender, EventArgs e)
        {
            buttonO.Visible = false;
            acertou = false;
            VerificarLetra('O');
            VerificarLetra('Ó');
            VerificarLetra('Ò');
            VerificarLetra('Õ');
            VerificarLetra('Ô');
            VerificarLetra('o');
            VerificarLetra('ó');
            VerificarLetra('ò');
            VerificarLetra('ô');
            VerificarLetra('õ');

            AtualizarJogo();
        }

        private void buttonP_Click(object sender, EventArgs e)
        {
            buttonP.Visible = false;
            acertou = false;
            VerificarLetra('P');
            VerificarLetra('p');

            AtualizarJogo();
        }

        private void buttonQ_Click(object sender, EventArgs e)
        {
            buttonQ.Visible = false;
            acertou = false;
            VerificarLetra('Q');
            VerificarLetra('q');

            AtualizarJogo();
        }

        private void buttonR_Click(object sender, EventArgs e)
        {
            buttonR.Visible = false;
            acertou = false;
            VerificarLetra('R');
            VerificarLetra('r');

            AtualizarJogo();
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            buttonS.Visible = false;
            acertou = false;
            VerificarLetra('S');
            VerificarLetra('s');

            AtualizarJogo();
        }

        private void buttonT_Click(object sender, EventArgs e)
        {
            buttonT.Visible = false;
            acertou = false;
            VerificarLetra('T');
            VerificarLetra('t');

            AtualizarJogo();
        }

        private void buttonU_Click(object sender, EventArgs e)
        {
            buttonU.Visible = false;
            acertou = false;
            VerificarLetra('U');
            VerificarLetra('Ú');
            VerificarLetra('u');
            VerificarLetra('ú');
            VerificarLetra('û');
            VerificarLetra('Û');

            AtualizarJogo();
        }

        private void buttonV_Click(object sender, EventArgs e)
        {
            buttonV.Visible = false;
            acertou = false;
            VerificarLetra('V');
            VerificarLetra('v');

            AtualizarJogo();
        }

        private void buttonW_Click(object sender, EventArgs e)
        {
            buttonW.Visible = false;
            acertou = false;
            VerificarLetra('W');
            VerificarLetra('w');

            AtualizarJogo();
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            buttonX.Visible = false;
            acertou = false;
            VerificarLetra('X');
            VerificarLetra('x');

            AtualizarJogo();
        }

        private void buttonY_Click(object sender, EventArgs e)
        {
            buttonY.Visible = false;
            acertou = false;
            VerificarLetra('Y');
            VerificarLetra('y');

            AtualizarJogo();
        }

        private void buttonZ_Click(object sender, EventArgs e)
        {
            buttonZ.Visible = false;
            acertou = false;
            VerificarLetra('Z');
            VerificarLetra('z');

            AtualizarJogo();
        }

        private void buttonDificuldade_Click(object sender, EventArgs e)
        {
            Dificuldade.Visible = true;
        }

        private void buttonFacil_Click(object sender, EventArgs e)
        {
            grau = "facil";
            buttonStart.Visible = true;
        }

        private void buttonMedio_Click(object sender, EventArgs e)
        {
            grau = "medio";
            buttonStart.Visible = true;
        }

        private void buttonDificil_Click(object sender, EventArgs e)
        {
            grau = "dificil";
            buttonStart.Visible = true;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {

            Stream st = Properties.Resources.Beat;

            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(st);
            sp.Stop();
            soundON = false;

            buttonA.Visible = true;
            buttonB.Visible = true;
            buttonC.Visible = true;
            buttonD.Visible = true;
            buttonE.Visible = true;
            buttonF.Visible = true;
            buttonG.Visible = true;
            buttonH.Visible = true;
            buttonI.Visible = true;
            buttonJ.Visible = true;
            buttonK.Visible = true;
            buttonL.Visible = true;
            buttonM.Visible = true;
            buttonN.Visible = true;
            buttonO.Visible = true;
            buttonP.Visible = true;
            buttonQ.Visible = true;
            buttonR.Visible = true;
            buttonS.Visible = true;
            buttonT.Visible = true;
            buttonU.Visible = true;
            buttonV.Visible = true;
            buttonW.Visible = true;
            buttonX.Visible = true;
            buttonY.Visible = true;
            buttonZ.Visible = true;
            buttonSpace.Visible = true;

            IniciarJogo();
        }

        private void buttonSpace_Click(object sender, EventArgs e)
        {
            buttonSpace.Visible = false;
            acertou = false;
            VerificarLetra(' ');

            AtualizarJogo();
        }

    }
}