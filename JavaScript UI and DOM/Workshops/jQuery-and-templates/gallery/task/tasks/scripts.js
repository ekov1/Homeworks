/* globals $ */
/// <reference path="C:\Downloads\Telerik\Homeworks\JavaScript UI and DOM\Workshops\jQuery Workshop\gallery\typings\jquery\jquery.d.ts" />

function solve() {
  $.fn.gallery = function (columns) {

    var cols = columns || 4,
      $containerList = $('.gallery-list'),
      $imageContainers = $containerList.children(),
      $prevImage = $('#previous-image'),
      $currentImage = $('#current-image'),
      $nextImage = $('#next-image'),
      $selected = $('.selected');

    $('#gallery').addClass('gallery');
    $selected.css('display', 'none');

    for (var i = 0; i < $imageContainers.length; i += 1) {
      $imageContainers.eq(i).children().attr('order', i);
      if (i % cols === 0) {
        $imageContainers.eq(i).addClass('clearfix');
      }
    }

    $containerList.on('click', function (ev) {
      var $target = $(ev.target);

      if ($('.gallery-list').hasClass('blurred')) {
        return;
      }

      $containerList.addClass('disabled-background').addClass('blurred');
      $selected.css('display', '');

      showPrev($target);
      showCurrent($target);
      showNext($target);
    });

    $selected.on('click', function (ev) {

      var target = $(ev.target),
        len = $imageContainers.length,
        index;

      if (target.parent('.current-image').length) {
        $('.selected').css('display', 'none');
        $('.gallery-list').removeClass('blurred');
        $('.gallery-list').removeClass('disabled-background');
      }
      else {
        index = +$(ev.target).attr('order');
        changeImages(index, len);
      }
    });

    function mod(m, n) {
      return (((m % n) + n) % n);
    }

    function showNext(targetNext) {
      if (targetNext.parent().next().length) {
        $nextImage.attr('src', targetNext.parent().next().children().attr('src'));
        $nextImage.attr('order', targetNext.parent().next().children().attr('order'));
      }
      else {
        $nextImage.attr('src', $('.gallery-list img').first().attr('src'));
        $nextImage.attr('order', $('.gallery-list img').first().attr('order'));
      }
    }

    function showPrev(targetPrev) {
      if (targetPrev.parent().prev().length) {
        $prevImage.attr('src', targetPrev.parent().prev().children().attr('src'));
        $prevImage.attr('order', targetPrev.parent().prev().children().attr('order'));
      }
      else {
        $prevImage.attr('src', $('.gallery-list img').last().attr('src'));
        $prevImage.attr('order', $('.gallery-list img').last().attr('order'));
      }
    }

    function showCurrent(target) {
      $currentImage.attr('src', target.attr('src'));
      $currentImage.attr('order', target.attr('order'));
    }

    function changeImages(index, len) {
      $('#previous-image').attr('src', 'imgs/' + (mod(index - 1, len) + 1) + '.jpg').attr('order', mod(index - 1, len));
      $('#current-image').attr('src', 'imgs/' + (mod(index, len) + 1) + '.jpg').attr('order', mod(index, len));
      $('#next-image').attr('src', 'imgs/' + (mod(index + 1, len) + 1) + '.jpg').attr('order', mod(index + 1, len));
      return;
    }
  };
}
module.exports = solve;