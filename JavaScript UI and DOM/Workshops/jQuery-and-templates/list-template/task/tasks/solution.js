function solve() {
    return function (selector) {
        var template = [
           '<div id="authors">',
	    '{{#each this}}',
				'{{#if right}}',
						'<div class="box right">',
					'{{/if}}',
					'{{#unless right}}',
						'<div class="box ">',
					'{{/unless}}',
						'<div class="inner">',
						 		'<p>',
          				'<img alt="{{name}}" src="{{image}}" width="100" height="133">',
        				'</p>',
								'<div>',
									'<h3>{{name}}</h3>',
									'{{#each titles}}',
          				 '<p>{{this}}</p>',
						'{{/each}}',
						'<ul>',
						'{{#each urls}}',
            			'<li>',
              			'<a href="{{this}}" target="_blank">{{this}}</a>',
            			'</li>',
           				'{{/each}}',
          				'</ul>',
						'</div>',
						 '</div>',
				'</div>',
			'{{/each}}',
			'</div>',
        '</div>'
        ].join('');

        document.getElementById(selector).innerHTML = template;
    };
}

if(typeof module !== 'undefined') {
    module.exports = solve;
}