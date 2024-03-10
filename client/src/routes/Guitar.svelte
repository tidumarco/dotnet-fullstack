<script lang="ts">
	import { createEventDispatcher } from 'svelte';

	export let guitarId: number | undefined;
	const dispatch = createEventDispatcher();

	async function deleteGuitar() {
		dispatch('guitarDeleted', { guitarId });
	}
</script>

<article class="custom-article">
	<h2 class="custom-heading">
		<slot name="name" />
	</h2>

	<div class="description">
		<h4 class="description-heading">Description</h4>
		<slot name="description" />
	</div>

	<div class="price">
		<slot name="price" />
	</div>

	<div>
		<button class="delete-button" on:click={deleteGuitar}> Delete </button>
	</div>
</article>

<style>
	.custom-article {
		border: 1px solid #ccc;
		border-radius: 0.375rem;
		box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
		padding: 1rem;
		margin-bottom: 1rem;
		display: flex;
		flex-direction: column;
		justify-content: space-between;
		height: 16rem;
		width: 16rem;
	}

	.custom-heading {
		font-size: 1.25rem;
		font-weight: 500;
		padding-bottom: 0.5rem;
		border-bottom: 2px solid orange;
	}

	.description-heading {
		font-weight: 600;
	}

	.delete-button {
		background-color: #f56565;
		color: #fff;
		border: none;
		border-radius: 5px;
		padding: 5px 10px;
		cursor: pointer;
	}

	.delete-button:hover {
		background-color: #e53e3e;
	}
</style>
