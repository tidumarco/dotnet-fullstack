<nav class="header-nav">
	<a href="/home" class="nav-link">Home</a>
	<a href="/add" class="nav-link">Add</a>
	<a href="/settings" class="nav-link">Settings</a>
</nav>

<slot />

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
