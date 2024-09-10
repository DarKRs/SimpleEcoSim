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

        public MovementService(AnimalService animalService)
        {
            _animalService = animalService;
        }

        public void MoveAll()
        {
            foreach (var movable in _animalService.Items.OfType<IMovable>())
            {
                MoveMovable(movable);
            }
        }

        private void MoveMovable(IMovable movable)
        {
            if (movable is Antelope antelope)
            {
                var nearestPlant = FindNearestPlant(antelope);
                var nearestLion = FindNearestLion(antelope);

                if (nearestLion != null && IsLionTooClose(antelope, nearestLion))
                {
                    MoveTowards(antelope, nearestLion.pos, -2);
                }
                else if (nearestPlant != null)
                {
                    MoveTowards(antelope, nearestPlant.pos, 2);
                }
            }
            // Логика для других существ
        }

        private Plant FindNearestPlant(Antelope antelope)
        {
            return _animalService.Items
                .OfType<Plant>()
                .OrderBy(p => GetDistance(antelope.pos, p.pos))
                .FirstOrDefault();
        }

        private Lion FindNearestLion(Antelope antelope)
        {
            return _animalService.Items
                .OfType<Lion>() 
                .OrderBy(l => GetDistance(antelope.pos, l.pos))
                .FirstOrDefault();
        }

        private bool IsLionTooClose(Antelope antelope, Lion lion)
            => GetDistance(antelope.pos, lion.pos) < 5;

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

        private void MoveTowards(Antelope antelope, Point target, double multiplier)
        {
            var direction = GetDirection(antelope.pos, target);
            antelope.Move(new Point((int)(direction.X * multiplier), (int)(direction.Y * multiplier)));
            antelope.pos = EnsureWithinBounds(antelope.pos);
        }
    }
}
