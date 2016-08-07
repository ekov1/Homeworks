/// <reference path="C:\Downloads\Telerik\Homeworks\JavaScript UI and DOM\Workshops\jQuery-and-templates\calendar-template\task\typings\handlebars\handlebars.d.ts" />
function solve() {
    return function (selector) {
        var template = [
            '<div class="events-calendar">',
            '<h2 class="header">',
                'Appointments for <span class="month">{{month}}</span> <span class="year">{{year}}</span>',
            '</h2>',
            '{{#each days}}',
                '<div class="col-date">',
                '<div class="date">{{day}}</div>',
                '<div class="events">',
                 '   {{#each events}}',
                     '   {{#if comment}}',
                      '  <div class="event {{importance}}" title="{{comment}}">',
                       ' {{/if}}',
                        ' {{#unless comment}}',
                        '<div class="event {{importance}}">',
                        '{{/unless}}',
                     '   {{#if title}}',
                      '      <div class="title">{{title}}</div>',
                       ' {{/if}}',
                        '{{#unless title}}',
                         '   <div class="title">Free slot</div>',
                        '{{/unless}}',
                       ' {{#if time}}',
                        '    <span class="time">at: {{time}}</span>',
                     '   {{/if}}',
                    '</div>',
                '    {{/each}}',
               ' </div>',
          '  </div>',
           ' {{/each}}',
       ' </div>'
        ].join('');

        if(template.length) {
            document.getElementById(selector).innerHTML = template;
        }
    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}