class Editor {

  grid;
  container;
  tile_size = 100;
  paintSelector;

  constructor(el, paintSelector) {
    this.container = el;
    this.paintSelector = paintSelector;
  }

  clearGrid() {
    this.container.innerHTML = '';
  }

  renderGrid(grid) {
    this.clearGrid()
    this.grid = grid;

    this.grid.getTileData().forEach((tile, index) => {
      let tileObj = new Tile(tile, (clicked_tile) => {
        let paintState = this.paintSelector.getState()

        console.log(`Geklikt op ${clicked_tile}`);
        console.log(`State = ${paintState}`);

        clicked_tile.setState(paintState);
      });
      this.grid.addTile(tileObj,);
    })

    this.grid.getTiles().forEach((tile, index) => {
      const x = (index % grid.getWidth()) * this.tile_size;
      const y = Math.floor(index / grid.getWidth()) * this.tile_size;
      tile.setPosition(x, y);
      this.container.appendChild(tile.getHtmlElement())
    })


  }

}
export default Editor;