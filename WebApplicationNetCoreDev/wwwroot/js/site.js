/* Validate repair validator.methods.range */
$.validator.methods.range = function (value, element, param) {
  var globalizedValue = value.replace(",", ".");
  return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
};
/* Validate repair validator.methods.number */
$.validator.methods.number = function (value, element) {
  value = value.replace(",", ".");
  return this.optional(element) || /-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
};
/* Validate repair Date format dd/MM/yyyy */
$.validator.methods.date = function (value, element) {
  var date = value.split("/");
  return this.optional(element) || !/Invalid|NaN/.test(new Date(date[2], date[1], date[0]).toString());
};

$(function () {
  try {
    if (kendo != null) {
      kendo.culture("pl-PL");
    }
  } catch (e) {
    console.log(e);
  }

  try {
    const color = window.$('.k-header').first().css('backgroundColor');
    window.$('.k-toolbar.k-grid-toolbar .k-form-legend').hide();
    window.$('.k-toolbar.k-grid-toolbar .k-widget.k-panelbar').css('border', 'none');
    window.$('.k-toolbar.k-grid-toolbar .k-content').css('border', 'none').css('margin-top', '-3rem').css('margin-left', '1rem');
    window.$('.k-toolbar.k-grid-toolbar .k-link').css('border', 'none').css('backgroundColor', color);
    window.$('.k-toolbar.k-grid-toolbar .k-panelbar .k-content').css('border', 'none').css('backgroundColor', color);
    window.$('.k-toolbar.k-grid-toolbar .k-grid-toolbar').css('border', 'none');
    window.$('.k-toolbar.k-grid-toolbar .toolbar').css('border', 'none');
    window.$('.k-toolbar.k-grid-toolbar .toolbar').children().css('border', 'none');
    window.$('.k-toolbar.k-grid-toolbar .k-form-buttons .k-button.k-primary.k-form-submit').text('Zastosuj filtrowanie');
    window.$('.k-toolbar.k-grid-toolbar .k-form-buttons .k-button.k-form-clear').text('Wyczyść formularz');
    window.kendo.culture("pl-PL");
  } catch (e) {
    console.log(e);
  }

});
