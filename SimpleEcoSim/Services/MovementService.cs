using SimpleEcoSim.Modles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcoSim.Services
{
    public class MovementService
    {
        private readonly AnimalService _animalService;
        private static readonly Random _random = new Random();

        public MovementService(AnimalService animalService)
        {
            _animalService = animalService;
        }

        public void MoveAll()
        {
            var movables = _animalService.Items.OfType<IMovable>().ToList();
            foreach (var movable in movables)
            {
                MoveMovable(movable);
            }
        }

        private void MoveMovable(IMovable movable)
        {
            switch (movable)
            {
                case Antelope antelope:
                    HandleAntelopeMovement(antelope);
                    break;

                case Lion lion:
                    HandleLionMovement(lion);
                    break;
            }
        }

        private void HandleAntelopeMovement(Antelope antelope)
        {
            var nearestPlant = FindNearest<Plant>(antelope);
            var nearestLion = FindNearest<Lion>(antelope);

            if (nearestLion != null && IsLionTooClose(antelope, nearestLion))
            {
                MoveAwayFrom(antelope, nearestLion.pos);
            }
            else if (nearestPlant != null && MoveTowards(antelope, nearestPlant.pos, 3))
            {
                _animalService.Items.Remove(nearestPlant);
                if (_random.Next(100) > 50)
                {
                    _animalService.AddItems<Antelope>(1);
                }
            }
        }

        private void HandleLionMovement(Lion lion)
        {
            var nearestAntelope = FindNearest<Antelope>(lion);

            if (nearestAntelope != null && MoveTowards(lion, nearestAntelope.pos, 3))
            {
                _animalService.Items.Remove(nearestAntelope);
                if(_random.Next(100) > 70) {
                    _animalService.AddItems<Lion>(1);
                }
                
            }
            else
            {
                MoveRandomly(lion);
            }
        }

        private T FindNearest<T>(Entity entity) where T : Entity
        {
            return _animalService.Items
                .OfType<T>()
                .OrderBy(e => GetDistance(entity.pos, e.pos))
                .FirstOrDefault();
        }

        private bool IsLionTooClose(Antelope antelope, Lion lion)
            => GetDistance(antelope.pos, lion.pos) < 5;

        private void MoveRandomly(Lion lion)
        {
            var angle = _random.NextDouble() * 2 * Math.PI;
            var direction = new PointF((float)Math.Cos(angle), (float)Math.Sin(angle));
            lion.pos = EnsureWithinBounds(new Point(
                lion.pos.X + (int)(direction.X * 1),
                lion.pos.Y + (int)(direction.Y * 1)));
        }

        private void MoveAwayFrom(Antelope antelope, Point threatPosition)
        {
            var direction = GetDirection(antelope.pos, threatPosition);
            antelope.pos = EnsureWithinBounds(new Point(
                antelope.pos.X - (int)(direction.X * 5),
                antelope.pos.Y - (int)(direction.Y * 5)));
        }

        private Point EnsureWithinBounds(Point pos)
        {
            int x = Math.Clamp(pos.X, 0, ConsoleService.WindowWidth - 1);
            int y = Math.Clamp(pos.Y, 0, ConsoleService.WindowHeight - 1);
            return new Point(x, y);
        }

        private double GetDistance(Point a, Point b)
            => Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

        private PointF GetDirection(Point from, Point to)
        {
            var deltaX = to.X - from.X;
            var deltaY = to.Y - from.Y;
            var magnitude = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            return magnitude == 0 ? new PointF(0, 0) : new PointF((float)(deltaX / magnitude), (float)(deltaY / magnitude));
        }

        private bool MoveTowards(Entity movable, Point target, double multiplier)
        {
            var direction = GetDirection(movable.pos, target);
            var newPosition = new Point(
                movable.pos.X + (int)(direction.X * multiplier),
                movable.pos.Y + (int)(direction.Y * multiplier));

            newPosition = EnsureWithinBounds(newPosition);
            bool reachedTarget = GetDistance(newPosition, target) < 2;
            movable.pos = newPosition;
            return reachedTarget;
        }
    }
}
