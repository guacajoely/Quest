using System;
using System.Collections.Generic;

namespace Quest
{
    public class Hat
    {
        public int Shininess { get; set;}
        public string ShininessDescription()
        {
            if(Shininess < 2){
                return "dull";
            }
            else if(Shininess > 1 && Shininess < 6){
                return "noticeable";
            }
            else if(Shininess > 5 && Shininess < 10){
                return "bright";
            }
            else{
                return "blinding";
            }
        }

    }
}