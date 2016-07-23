/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 
*/
function solve() {
  return function (selector) {

    var elements,
      targetButton,
      next,
      buttons;

    if (typeof selector !== 'string' || $(selector).size() === 0) {
      throw Error();
    }

    buttons = $('.button');

    $(buttons).each(function () {
      $(this).text('hide');
    });

    $(selector).on('click', function (ev) {

      targetButton = $(ev.target);
      next = targetButton.next();

      // If something different from a button is clicked
      if (!(targetButton.hasClass('button'))) {
        return;
      }

      // Cycle until next content is with class button
      while (next) {
        if (next.hasClass('content')) {
          break;
        }
        next = next.next();
      }

      if (next.css("display") === "none") {
        next.css("display", "");
        $(targetButton).text('hide');
      }
      else {
        next.hide();
        $(targetButton).text('show');
      }
    });
  };
}

module.exports = solve;