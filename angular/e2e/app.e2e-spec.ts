import { SmartCompanyTemplatePage } from './app.po';

describe('SmartCompany App', function() {
  let page: SmartCompanyTemplatePage;

  beforeEach(() => {
    page = new SmartCompanyTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
