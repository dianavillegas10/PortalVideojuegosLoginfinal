using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PortalVideojuegos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CrearInterfaz();
        }

        private void CrearInterfaz()
        {
            
            this.Text = "Portal de Videojuegos";
            this.Size = new Size(1000, 700);
            this.BackColor = Color.FromArgb(32, 34, 37);
            this.StartPosition = FormStartPosition.CenterScreen;

           
            CrearEncabezado();

            
            CrearMenuLateral();

            
            CrearAreaJuegos();

            
            CrearSeccionPerfil();
        }

        private void CrearEncabezado()
        {
            Panel headerPanel = new Panel();
            headerPanel.Size = new Size(1000, 80);
            headerPanel.BackColor = Color.FromArgb(44, 47, 51);
            headerPanel.Dock = DockStyle.Top;

            // Título principal
            Label titulo = new Label();
            titulo.Text = "TENDA COMUNIDAD SOPORTE";
            titulo.Font = new Font("Arial", 16, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.AutoSize = true;
            titulo.Location = new Point(20, 25);

            headerPanel.Controls.Add(titulo);
            this.Controls.Add(headerPanel);
        }

        private void CrearMenuLateral()
        {
            Panel menuPanel = new Panel();
            menuPanel.Size = new Size(200, 620);
            menuPanel.BackColor = Color.FromArgb(54, 57, 63);
            menuPanel.Location = new Point(0, 80);

            // las ociones del menu
            string[] opciones = { "Destacados", "Mis juegos", "Configuración" };
            int posY = 30;

            foreach (string opcion in opciones)
            {
                Label menuItem = new Label();
                menuItem.Text = "• " + opcion;
                menuItem.Font = new Font("Arial", 12);
                menuItem.ForeColor = Color.White;
                menuItem.AutoSize = true;
                menuItem.Location = new Point(20, posY);
                menuItem.Cursor = Cursors.Hand;

                // cambiar color al pasar por encima
                menuItem.MouseEnter += (s, e) => { menuItem.ForeColor = Color.LightBlue; };
                menuItem.MouseLeave += (s, e) => { menuItem.ForeColor = Color.White; };

                menuPanel.Controls.Add(menuItem);
                posY += 40;
            }

            this.Controls.Add(menuPanel);
        }

        private void CrearAreaJuegos()
        {
            Panel contentPanel = new Panel();
            contentPanel.Size = new Size(800, 620);
            contentPanel.BackColor = Color.FromArgb(32, 34, 37);
            contentPanel.Location = new Point(200, 80);

            // jueguitos
            Label tituloJuegos = new Label();
            tituloJuegos.Text = "JUEGOS DISPONIBLES";
            tituloJuegos.Font = new Font("Arial", 14, FontStyle.Bold);
            tituloJuegos.ForeColor = Color.White;
            tituloJuegos.AutoSize = true;
            tituloJuegos.Location = new Point(30, 20);
            contentPanel.Controls.Add(tituloJuegos);

           
            int posX = 30;

          
            Panel juego1 = CrearPanelJuego("Red Dead Redemption 2", "Aventura en el lejano oeste", "imagenes/rdr2caratula.jpg");
            juego1.Location = new Point(posX, 60);
            contentPanel.Controls.Add(juego1);
            posX += 220;

            
            Panel juego2 = CrearPanelJuego("The Sims 4", "Simulación de vida", "imagenes/sims4.jpg");
            juego2.Location = new Point(posX, 60);
            contentPanel.Controls.Add(juego2);
            posX += 220;

            
            Panel juego3 = CrearPanelJuego("Fortnite", "Battle Royale", "imagenes/FORTNITE.jpg");
            juego3.Location = new Point(posX, 60);
            contentPanel.Controls.Add(juego3);

            this.Controls.Add(contentPanel);
        }

        private Panel CrearPanelJuego(string nombreJuego, string descripcion, string rutaImagen = "")
        {
            Panel panelJuego = new Panel();
            panelJuego.Size = new Size(200, 350);
            panelJuego.BackColor = Color.FromArgb(44, 47, 51);
            panelJuego.BorderStyle = BorderStyle.FixedSingle;

            // IMAGEN DEL JUEGO - CÓDIGO NUEVO
            PictureBox imagenJuego = new PictureBox();
            imagenJuego.Size = new Size(180, 150);
            imagenJuego.Location = new Point(10, 10);
            imagenJuego.SizeMode = PictureBoxSizeMode.StretchImage;
            imagenJuego.BackColor = Color.FromArgb(64, 68, 75);

            // VERIFICAR SI LA IMAGEN EXISTE
            bool imagenCargada = false;

            if (!string.IsNullOrEmpty(rutaImagen))
            {
                string rutaCompleta = Path.Combine(Application.StartupPath, rutaImagen);

                if (File.Exists(rutaCompleta))
                {
                    try
                    {
                        imagenJuego.Image = Image.FromFile(rutaCompleta);
                        imagenCargada = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error cargando imagen: {ex.Message}");
                    }
                }
            }

        
            if (!imagenCargada)
            {
                Label textoPlaceholder = new Label();
                textoPlaceholder.Text = nombreJuego + "\n[Imagen no encontrada]\n" + rutaImagen;
                textoPlaceholder.Font = new Font("Arial", 7, FontStyle.Bold);
                textoPlaceholder.ForeColor = Color.Yellow;
                textoPlaceholder.TextAlign = ContentAlignment.MiddleCenter;
                textoPlaceholder.Size = new Size(180, 150);
                textoPlaceholder.Location = new Point(0, 0);
                imagenJuego.Controls.Add(textoPlaceholder);
            }


          
            Label nombre = new Label();
            nombre.Text = nombreJuego;
            nombre.Font = new Font("Arial", 12, FontStyle.Bold);
            nombre.ForeColor = Color.White;
            nombre.AutoSize = false;
            nombre.Size = new Size(180, 30);
            nombre.Location = new Point(10, 170);
            nombre.TextAlign = ContentAlignment.MiddleCenter;

            Label desc = new Label();
            desc.Text = descripcion;
            desc.Font = new Font("Arial", 9);
            desc.ForeColor = Color.LightGray;
            desc.AutoSize = false;
            desc.Size = new Size(180, 40);
            desc.Location = new Point(10, 200);
            desc.TextAlign = ContentAlignment.MiddleCenter;

          
            Button botonDetalles = new Button();
            botonDetalles.Text = "Ver detalles";
            botonDetalles.Size = new Size(100, 30);
            botonDetalles.Location = new Point(50, 250);
            botonDetalles.BackColor = Color.FromArgb(88, 101, 242);
            botonDetalles.ForeColor = Color.White;
            botonDetalles.FlatStyle = FlatStyle.Flat;
            botonDetalles.Cursor = Cursors.Hand;

            
            botonDetalles.Click += (s, e) =>
            {
                MessageBox.Show($"Juego: {nombreJuego}\n\nDescripción: {descripcion}\n\nPrecio: $59.99", "Información del Juego");
            };

            
            Button botonComprar = new Button();
            botonComprar.Text = "Comprar";
            botonComprar.Size = new Size(100, 30);
            botonComprar.Location = new Point(50, 290);
            botonComprar.BackColor = Color.FromArgb(35, 168, 109);
            botonComprar.ForeColor = Color.White;
            botonComprar.FlatStyle = FlatStyle.Flat;
            botonComprar.Cursor = Cursors.Hand;

            botonComprar.Click += (s, e) =>
            {
                MessageBox.Show($"¡Has comprado {nombreJuego}!\n\nGracias por tu compra.", "Compra Exitosa");
            };

            //controles
            panelJuego.Controls.Add(imagenJuego);
            panelJuego.Controls.Add(nombre);
            panelJuego.Controls.Add(desc);
            panelJuego.Controls.Add(botonDetalles);
            panelJuego.Controls.Add(botonComprar);

            return panelJuego;
        }

        private void CrearSeccionPerfil()
        {
            
            Panel panelPerfil = new Panel();
            panelPerfil.Size = new Size(100, 35);
            panelPerfil.BackColor = Color.FromArgb(88, 101, 242);
            panelPerfil.Location = new Point(880, 10);  


            Label perfil = new Label();
            perfil.Text = "👤 Perfil";
            perfil.Font = new Font("Arial", 9, FontStyle.Bold);
            perfil.ForeColor = Color.White;
            perfil.AutoSize = true;
            perfil.Location = new Point(10, 8);
            perfil.Cursor = Cursors.Hand;

            perfil.Click += (s, e) =>
            {
                MessageBox.Show("Perfil del usuario\n\nNombre: Jugador\nNivel: 25\nJuegos: 15", "Mi Perfil");
            };

            panelPerfil.Controls.Add(perfil);
            this.Controls.Add(panelPerfil);
            panelPerfil.BringToFront();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}