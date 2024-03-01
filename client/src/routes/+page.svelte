<script>
	import { onMount } from 'svelte';

	let data;

	onMount(async () => {
		// const response = await fetch('https://jsonplaceholder.typicode.com/posts');
		const response = await fetch('http://localhost:5024/Guitar');
		// response.headers.append('Access-Control-Allow-Origin', 'http://localhost:5024');
		data = await response.json();
		console.log('data', data);
	});
</script>

<h1>Welcome to SvelteKit</h1>
<p>Visit <a href="https://kit.svelte.dev">kit.svelte.dev</a> to read the documentation</p>
