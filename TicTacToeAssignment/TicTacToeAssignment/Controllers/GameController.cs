using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicTacToeAssignment.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        static List<int> blockedList = new List<int>();
        static List<string> EmailList = new List<string>();
        static List<int> Player1 = new List<int>();
        static List<int> Player2 = new List<int>();
        static string player1;
        static bool IsPlayer1Play = true;
        static bool IsPlayer2Play = true;
        static string player2;
        static int countMoves = 0;
        static int flag = 0;
        static int count = 0;
        static string winner = null;

        public string check()
        {
            if (Player1.Contains(1) && Player1.Contains(2) && Player1.Contains(3) || Player1.Contains(4) && Player1.Contains(5) && Player1.Contains(6) || Player1.Contains(7) && Player1.Contains(8) && Player1.Contains(9) || Player1.Contains(1) && Player1.Contains(4) && Player1.Contains(7) || Player1.Contains(2) && Player1.Contains(5) && Player1.Contains(8) || Player1.Contains(3) && Player1.Contains(6) && Player1.Contains(9) || Player1.Contains(1) && Player1.Contains(5) && Player1.Contains(9) || Player1.Contains(3) && Player1.Contains(5) && Player1.Contains(7))
            {
                return "Player One wins";
            }
            else if (Player2.Contains(1) && Player2.Contains(2) && Player2.Contains(3) || Player2.Contains(4) && Player2.Contains(5) && Player2.Contains(6) || Player2.Contains(7) && Player2.Contains(8) && Player2.Contains(9) || Player2.Contains(1) && Player2.Contains(4) && Player2.Contains(7) || Player2.Contains(2) && Player2.Contains(5) && Player2.Contains(8) || Player2.Contains(3) && Player2.Contains(6) && Player2.Contains(9) || Player2.Contains(1) && Player2.Contains(5) && Player2.Contains(9) || Player2.Contains(3) && Player2.Contains(5) && Player2.Contains(7))
            {
                return "Player Two wins";
            }
            else
            {
                if (countMoves == 9)
                    return "DrAW";

            }
            return "In Progress";

        }
        // GET: api/values
        [HttpGet]
        [Authorized]
        [Log]
        [Exception]
        public string GetStatus()
        {
            if (countMoves < 9)
            {
                return "In Progress";
            }
            else
            {
                if (Player1.Contains(1) && Player1.Contains(2) && Player1.Contains(3) || Player1.Contains(4) && Player1.Contains(5) && Player1.Contains(6) || Player1.Contains(7) && Player1.Contains(8) && Player1.Contains(9) || Player1.Contains(1) && Player1.Contains(4) && Player1.Contains(7) || Player1.Contains(2) && Player1.Contains(5) && Player1.Contains(8) || Player1.Contains(3) && Player1.Contains(6) && Player1.Contains(9) || Player1.Contains(1) && Player1.Contains(5) && Player1.Contains(9) || Player1.Contains(3) && Player1.Contains(5) && Player1.Contains(7))
                {
                    return "Player One wins";
                }
                else if (Player2.Contains(1) && Player2.Contains(2) && Player2.Contains(3) || Player2.Contains(4) && Player2.Contains(5) && Player2.Contains(6) || Player2.Contains(7) && Player2.Contains(8) && Player2.Contains(9) || Player2.Contains(1) && Player2.Contains(4) && Player2.Contains(7) || Player2.Contains(2) && Player2.Contains(5) && Player2.Contains(8) || Player2.Contains(3) && Player2.Contains(6) && Player2.Contains(9) || Player2.Contains(1) && Player2.Contains(5) && Player2.Contains(9) || Player2.Contains(3) && Player2.Contains(5) && Player2.Contains(7))
                {
                    return "Player Two wins";
                }
                else
                {
                    return "Draw";
                }

            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/values
        [HttpPost]
        [Authorized]
        [Log]
        [Exception]
        public string MakeMoves([FromHeader]string Email, [FromHeader] int BoxId)
        {
            count++;

            if (!EmailList.Contains(Email))
            {
                EmailList.Add(Email);

            }
            if (count < 3)
            {


                if (EmailList.Count == 1)
                {
                    player1 = Email;
                }
                if (EmailList.Count == 2)
                {
                    player2 = Email;

                }
            }

            if (EmailList.Count <= 2)
            {
                if (BoxId < 1 && BoxId > 9)
                {
                    throw new Exception("Enter valid Box Id");
                }

                if (IsPlayer1Play)
                {
                    if (player1 == Email)
                    {
                        IsPlayer1Play = false;
                        IsPlayer2Play = true;
                        if (!blockedList.Contains(BoxId))
                        {
                            blockedList.Add(BoxId);
                            Player1.Add(BoxId);
                            countMoves++;

                            winner = check();


                        }
                        else
                        {
                            throw new Exception("Box Id Blocked");
                        }
                    }
                    else
                    {
                        throw new Exception("User Already Played ");
                    }
                }
                
                else if (IsPlayer2Play)
                {
                    if (player2 == Email)
                    {
                        IsPlayer2Play = false;
                        IsPlayer1Play = true;
                        if (!blockedList.Contains(BoxId))
                        {
                            blockedList.Add(BoxId);
                            Player2.Add(BoxId);
                            countMoves++;
                            winner = check();

                        }
                        else
                        {
                            throw new Exception("Box Id Blocked");
                        }
                    }
                    else
                    {
                        throw new Exception("User Already Played ");
                    }
                }
            }
            if (EmailList.Count > 2)
            {
                throw new Exception("Only Two players can play the game");
            }


            return winner;
        }





        // PUT api/values/

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
