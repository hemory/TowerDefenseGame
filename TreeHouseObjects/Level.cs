﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using TreehouseDefense;

namespace TreeHouseObjects
{
    class Level
    {
        private readonly Invader[] _invaders;
        public Tower[] Towers { get; set; }

        public Level(Invader[] invaders)
        {
            _invaders = invaders;
        }

        //returns true if the player wins or false if the player loses
        public bool Play()
        {
            // Run until all invaders are neutralized or an invader eaches the end of path.
            int remainingInvaders = _invaders.Length;

            while (remainingInvaders > 0)
            {
                //Each tower has an opportuntiy to fire on invaders.
                foreach (Tower tower in Towers)
                {
                    tower.FireOnInvaders(_invaders);
                }
                //Count and move the invaders that ae still active.
                remainingInvaders = 0;
                foreach (Invader invader in _invaders)
                {
                    if (invader.IsActive)
                    {
                        invader.Move();

                        if (invader.HasScored)
                        {
                            return false;
                        }
                        remainingInvaders++;
                    }
                }
            }

            return true;


        }
    }
}
