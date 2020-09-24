namespace GridMaze.Maze
{
    public class WallSelector
    {
        public Line SelectedLine { get; private set; }

        private readonly MazeGrids mazeGrids;

        private int horizontalWallIndex = 0;
        private int verticalWallIndex = 0;
        private bool isHorizontalSelection = true;


        public WallSelector(MazeGrids mazeGrids)
        {
            this.mazeGrids = mazeGrids;
            SelectedLine = mazeGrids.GetLineHorizontal(0);
        }

        public void ResumeSelection()
        {
            foreach (var wall in SelectedLine.Walls)
            {
                WallOutliner.Select(wall.Renderer);
            }
        }

        public void CleanSelection()
        {
            foreach (var wall in SelectedLine.Walls)
            {
                WallOutliner.Deselect(wall.Renderer);
            }
        }

        public void SelectNextLine()
        {
            if (isHorizontalSelection)
            {
                horizontalWallIndex++;
            }
            else
            {
                verticalWallIndex++;
            }

            UpdateCurrentSelection();
        }

        public void SwitchLines()
        {
            // CleanSelection();
            isHorizontalSelection = !isHorizontalSelection;
            UpdateCurrentSelection();
        }

        private void UpdateCurrentSelection()
        {
            CleanSelection();
            
            SelectedLine = isHorizontalSelection
                ? mazeGrids.GetLineHorizontal(horizontalWallIndex)
                : mazeGrids.GetLineVertical(verticalWallIndex);

            ResumeSelection();
        }
    }
}