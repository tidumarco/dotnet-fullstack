<article class="guitar-card">
	<h2>
		<slot name="name" />
	</h2>

	<div class="description">
		<h4>Description</h4>
		<slot name="description" />
	</div>

	<div class="price">
		<slot name="price" />
	</div>
</article>

<style>
	.guitar-card {
		width: 250px;
		border: 1px solid #aaa;
		border-radius: 2px;
		box-shadow: 2px 2px 8px rgba(0, 0, 0, 0.1);
		padding: 1em;
		margin-bottom: 20px;
	}

	h2 {
		padding: 0 0 0.2em 0;
		margin: 0 0 1em 0;
		border-bottom: 1px solid #ff3e00;
	}

	.description,
	.price {
		padding: 0 0 10px 1.5em;
		margin: 0 0 0.5em 0;
		line-height: 1.2;
	}
</style>
