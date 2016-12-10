using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class HighScore
{
    public String Score { get; set; }
    public String Usuario { get; set; }
    public String Password { get; set; }


    public HighScore(String usuario, String password, String score)
    {
        this.Usuario = usuario;
        this.Password = password;
        this.Score = score;
    }

    
}

