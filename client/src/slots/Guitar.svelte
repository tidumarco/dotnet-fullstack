<script lang="ts">
	import { createEventDispatcher } from 'svelte';

	export let guitarId: number | undefined;
	const dispatch = createEventDispatcher();

	async function deleteGuitar() {
		dispatch('guitarDeleted', { guitarId });
	}
</script>

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
	<div>
		<button on:click={deleteGuitar}>Delete</button>
	</div>
</article>

<style>
	.guitar-card {
		display: flex;
		flex-direction: column;
		justify-content: space-evenly;
		height: 250px;
		width: 250px;
		border: 1px solid #aaa;
		border-radius: 2px;
		box-shadow: 2px 2px 8px rgba(0, 0, 0, 0.1);
		padding: 1em;
		margin-bottom: 20px;
	}
	.description,
	.price {
		padding: 10px 0 10px 0;
	}

	h2 {
		border-bottom: 1px solid #ff3e00;
	}

	button {
		background-color: #ff3e00;
		color: white;
		border: none;
		border-radius: 4px;
		padding: 0.5em 1em;
		cursor: pointer;
	}

	button:hover {
		background-color: #ff5c33;
	}
</style>
