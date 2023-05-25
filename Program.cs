using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        
        // P8. WE NEED TO STORE THE CURRENT SUCCESS COUNT OUT HERE BECAUSE ITS SHARED ACCROSS MULTIPLE GAMES
        public static int successfulChallengeCount = 0;

        public static void IncreaseChallengeCount()
        {
            successfulChallengeCount++;
        }
        static void Main(string[] args)
        {
    
            Game();

        }

        static void Game()
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?",
                42,
                25
            );
            Challenge whatSecond = new Challenge(
                "What is the current second?",
                DateTime.Now.Second,
                50
            );

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge(
                "What number am I thinking of?",
                randomNumber,
                25
            );

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4,
                20
            );
            Challenge joelsQuestionOne = new Challenge("How many fingers am I holding up?", 1, 10);
            Challenge joelsQuestionTwo = new Challenge("3x3?", 9, 10);
            Challenge joelsQuestionThree = new Challenge("420+69?", 489, 10);


            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // P2. PROMPT USER FOR THEIR NAME
            string userName;

            Console.WriteLine();
            Console.Write("What is your adventurer's name?");
            userName = Console.ReadLine();


            // Make a new "Robe" object using the "Robe" class
            var adventurersRobe = new Robe{
                Color = "red",
                Length = 22
            };

            var adventurersHat = new Hat{
                Shininess = 6
            };

            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(userName, adventurersRobe, adventurersHat);

            // P3. Call GetDescription before user starts challenges
            Console.WriteLine(theAdventurer.GetDescription());
            Console.WriteLine();

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                joelsQuestionOne,
                joelsQuestionTwo,
                joelsQuestionThree
            };


            // // Loop through all the challenges and subject the Adventurer to them
            // foreach (Challenge challenge in challenges)
            // {
            //     challenge.RunChallenge(theAdventurer);
            // }
            //P7 INSTEAD OF LOOPING THROUGH ALL THE CHALLENGES IN THE CODE ABOVE, LETS RANDOMLY SELECT 5 OF THEM

            //WE HAVE 8 QUESTIONS, SO WE NEED A RANDOM INDEX BETWEEN 0 AND 7
            int getRandomInt()
            {
                int newNum = new Random().Next(0, 7);
                return newNum;
            }

            //LETS STORE THE RANDOM INDEX WE'VE MADE IN AN ARRAY, BUT ONLY IF ITS NOT ALREADY IN THERE (no duplicates)
            var indexes = new List<int>();
            while (indexes.Count < 5)
            {
                int candidate = getRandomInt();
                if (!indexes.Contains(candidate))
                {
                    indexes.Add(candidate);
                }
            }

            //ONCE THERE ARE 5 RANDOM INDEXES IN THE ARRAY, WE'LL RUN EACH
            //WE COULD ALSO USE A FOREACH HERE, MAY BE MORE READABLE
            for (var i = 0; i < indexes.Count; i++)
            {
                int currentIndex = indexes[i];
                Challenge currentChallenge = challenges[currentIndex];
                currentChallenge.RunChallenge(theAdventurer);
            }


            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
            if (theAdventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine(
                    "I guess you did...ok? ...sorta. Still, you should get out of my sight."
                );
            }

            Console.WriteLine($"You completed {successfulChallengeCount} challenges. This will give you a head start in your next game!");
            Prize(theAdventurer);
            Replay();

        }

        // P3. ONCE GAME ENDS PROMPT PLAY AGAIN QUESTION
        static void Replay()
        {
            Console.WriteLine();
            Console.Write($"Play Again? (Y/N):");
            string answer = Console.ReadLine().ToLower();

            while (answer != "y" && answer != "n")
            {
                Console.Write($"Play Again? (Y/N):");
                answer = Console.ReadLine().ToLower();
            }

            if (answer == "y")
            {
                Game();
            }
            else
            {
                return;
            }
        }


        // P6. AFTER GAME, BEFORE REPLAY, GIVE USER PRIZE

        static void Prize(Adventurer adventurer){

        Prize AdventurersPrize = new Prize("You win 1 gold coin!");
        AdventurersPrize.ShowPrize(adventurer);

        }
    }
}
