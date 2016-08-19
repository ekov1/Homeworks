function solve() {
	return function () {
		var template = [
			'<h1>{{title}}</h1>',
			'<ul>',
			'{{#each posts}}',
			'<li>',
			'<div class="post">',
			'<p class="author">',
			'{{#if author}}',
			'<a class="user" href="/user/{{author}}">{{author}}</a>',
			'{{/if}}',
			'{{#unless author}}',
			'<a class="anonymous">Anonymous</a>',
			'{{/unless}}',
			'</p>',
			'<pre class="content">{{{text}}}</pre>',
			'</div>',
			'<ul>',
			'{{#each comments}}',
			'{{#if deleted}}',
			'{{/if}}',
			'{{#unless deleted}}',
			'<li>',
			'<div class="comment">',
			'<p class="author">',
			'{{#if author}}',
			'<a class="user" href="/user/{{author}}">{{author}}</a>',
			'{{/if}}',
			'{{#unless author}}',
			'<a class="anonymous">Anonymous</a>',
			'{{/unless}}',
			'</p>',
			'<pre class="content">{{{text}}}</pre>',
			'</div>',
			'</li>',
			'{{/unless}}',
			'{{/each}}',
			'</ul>',
			'</li>',
			'{{/each}}',
			'</ul>'
		].join('\n');

		return template;
	};
}

// submit the above

if (typeof module !== 'undefined') {
	module.exports = solve;
}
