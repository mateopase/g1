using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Engine.Physics
{
    public class CollisionGrid
    {
        // TODO A dict is nice because it's sparse, but a preallocated
        //      array or 2D array could be faster.
        // TODO The IList should be some kind of custom object that
        //      can also filter by layer (if collision layers are necessary)
        private Dictionary<Vector2, ISet<BoundingBox2>> _cells;
        private int _cellSize;

        public CollisionGrid(int width, int height, int cellSize)
        {
            this._cells = new Dictionary<Vector2, ISet<BoundingBox2>>();
        }

        public void Insert(BoundingBox2 box)
        {
            foreach (var cell in this.GetContainingCells(box))
            {
                if (!this._cells.ContainsKey(cell))
                {
                    this._cells[cell] = new HashSet<BoundingBox2>(1);
                }

                this._cells[cell].Add(box);
            }
        }

        public void Remove(BoundingBox2 box)
        {
            foreach (var cell in this.GetContainingCells(box))
            {
                this._cells[cell].Remove(box);
            }
        }

        public ISet<BoundingBox2> Query(BoundingBox2 box)
        {
            var boxesToCheck = new HashSet<BoundingBox2>();

            foreach (var cell in this.GetContainingCells(box))
            {
                boxesToCheck.UnionWith(this._cells[cell]);
            }

            return boxesToCheck;
        }

        private IEnumerable<Vector2> GetContainingCells(BoundingBox2 box)
        {
            var rect = box.Rectangle;

            int xMin = (int)rect.Left / this._cellSize;
            int xMax = (int)rect.Right / this._cellSize;
            int yMin = (int)rect.Top / this._cellSize;
            int yMax = (int)rect.Bottom / this._cellSize;

            for (int x = xMin; x <= xMax; x++)
            {
                for (int y = yMin; y <= yMax; y++)
                {
                    yield return new Vector2(x, y);
                }
            }
        }
    }
}