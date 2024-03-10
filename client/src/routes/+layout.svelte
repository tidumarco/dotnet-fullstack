<script>
	import '../app.css';
</script>

<nav>
	<a href="/" class="nav-link">Home</a>
	<a href="/add" class="nav-link">Add</a>
	<a href="/about" class="nav-link">About me</a>
</nav>

<div class="app">
	<main>
		<slot />
	</main>
</div>
