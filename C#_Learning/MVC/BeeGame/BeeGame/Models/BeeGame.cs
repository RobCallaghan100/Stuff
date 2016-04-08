namespace BeeGame.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BeeGame
    {
        private QueenBee _queenBee;
        private List<WorkerBee> _workerBees;
        private List<DroneBee> _droneBees;

        public QueenBee QueenBee
        {
            get { return _queenBee;}
        }

        public List<WorkerBee> WorkerBees
        {
            get { return _workerBees; }
        }

        public List<DroneBee> DroneBees
        {
            get { return _droneBees; }
        }

        public BeeGame()
        {
            ResetBees();
        }

        private void ResetBees()
        {
            InitialiseQueenBee();
            InitialiseWorkerBees();
            InitialiseDroneBees();
        }

        private void InitialiseQueenBee()
        {
            _queenBee = new QueenBee(100);
        }

        private void InitialiseWorkerBees()
        {
            _workerBees = new List<WorkerBee>();
            for (int i = 0; i < 5; i++)
            {
                _workerBees.Add(new WorkerBee(75));
            }
        }

        private void InitialiseDroneBees()
        {
            _droneBees = new List<DroneBee>();
            for (int i = 0; i < 8; i++)
            {
                _droneBees.Add(new DroneBee(50));
            }
        }

        public void Hit()
        {   
            Random random = new Random();

            var beeType = random.Next(1, 3);

            beeType = 1;//TODO: remove

            switch (beeType)
            {
                case 1:
                    _queenBee.Hit();
                    break;

                case 2:
                    _workerBees.ElementAt(random.Next(1, 5)).Hit();
                    break;

                case 3:
                    _droneBees.ElementAt(random.Next(1, 8)).Hit();
                    break;

                default:
                    throw new ApplicationException("Should not happen");
            }
        }
    }
}