<script>
	import '../app.css';
</script>

<nav class="header-nav">
	<a href="/" class="nav-link">Home</a>
	<a href="/add" class="nav-link">Add</a>
	<a href="/about" class="nav-link">About me</a>
</nav>

<div class="app">
	<main>
		<slot />
	</main>
</div>

<style>
	.header-nav {
		background-color: #333;
		color: #fff;
		padding: 10px;
	}

	.nav-link {
		color: #fff;
		text-decoration: none;
		margin-right: 10px;
		padding: 5px 10px;
		border-radius: 4px;
	}

	.nav-link:hover {
		background-color: #555;
	}
</style>
