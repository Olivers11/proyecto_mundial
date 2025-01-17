﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_mundial
{
    public partial class addPlayer : Form
    {
        private List<TeamModel> teams;
        public addPlayer()
        {
            InitializeComponent();
            this.teams = new List<TeamModel>();
            this.fillTeams();
        }

        public void fillTeams()
        {
            TeamController tc = new TeamController();
             teams = tc.getTeams();
            foreach(TeamModel team in teams)
            {
                this.team_combo.Items.Add(team.name);
            }
        }

        public int getId(String name)
        {
            foreach(TeamModel team in this.teams)
            {
                Console.WriteLine(team.name+ " and " + name);
                if (team.name.ToLower().Equals(name.ToLower()))
                {
                    Console.WriteLine("Es Esta!");
                    return team.id;
                }
            }
            return -1;
        }

        public bool isEmpty()
        {
            return txt_asistencias.Text == "" || txt_apellido.Text == "" || txt_gol.Text == "" || txt_minutos.Text == "" || txt_nombre.Text == "" || txt_posicion.Text == "";

        }

        public void clearComponents()
        {
            txt_apellido.Text = "";
            txt_asistencias.Text = "";
            txt_gol.Text = "";
            txt_minutos.Text = "";
            txt_nombre.Text = "";
            txt_age.Text = "";
            txt_posicion.Text = "";
        }


        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (this.isEmpty())
            {
                MessageBox.Show("Debe llenar todos los campos antes");
                return;
            }

            String name_pais = this.team_combo.GetItemText(this.team_combo.SelectedItem);
            int id_pais = this.getId(name_pais);
            int edad = Convert.ToInt32(txt_age.Text); 

            playerModel player = new playerModel(txt_nombre.Text
                , txt_apellido.Text,
                edad,
                txt_posicion.Text,
                Convert.ToInt32(txt_asistencias.Text),
                Convert.ToInt32(txt_minutos.Text),
                id_pais,
                Convert.ToInt32(txt_gol.Text));
            PlayerController pc = new PlayerController();
            pc.insertPlayer(player);
            MessageBox.Show("Jugador Guardado :D");
            this.clearComponents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.clearComponents();
        }
    }
}






