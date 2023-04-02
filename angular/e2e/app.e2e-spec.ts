import { GranHotelKataTemplatePage } from './app.po';

describe('GranHotelKata App', function() {
  let page: GranHotelKataTemplatePage;

  beforeEach(() => {
    page = new GranHotelKataTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
