<script lang="ts">
	import { onMount } from 'svelte';
	import GuitarCard from './Guitar.svelte';
	import type { Guitar } from '../types/Guitar';
	let data: Guitar[];
	let loadingState = true;
	let confirmationMessage = '';

	onMount(async () => {
		try {
			const response = await fetch('https://guitar-backend.azurewebsites.net/Guitar');
			// const response = await fetch('http://localhost:5024/Guitar');
			data = await response.json();
			loadingState = false;
		} catch (error) {}
	});

	async function handleDelete(event: any) {
		const deletedGuitarId = event.detail.guitarId;

		try {
			const response = await fetch(
				`https://guitar-backend.azurewebsites.net/guitar/${deletedGuitarId}`,
				{
					// const response = await fetch(`http://localhost:5024/guitar/${deletedGuitarId}`, {
					method: 'DELETE'
				}
			);
			if (response.ok) {
				confirmationMessage = 'Guitar deleted successfully';
				window.alert(confirmationMessage);
				window.location.reload();
			} else {
				confirmationMessage = 'Failed to add guitar';
				window.alert(confirmationMessage);
				console.error(confirmationMessage);
			}
		} catch (error) {
			console.error('Error deleting guitar:', error);
		}
	}
</script>

<h1>Marco's Guitars</h1>

{#if loadingState == true}
	<h2>Loading...</h2>
{:else}
	<div class="guitar-list">
		{#each data as guitar}
			<GuitarCard guitarId={guitar.id} on:guitarDeleted={handleDelete}>
				<span slot="name">{guitar.name}</span>
				<span slot="description">
					{guitar.description}
				</span>
				<span slot="price" style="font-style: italic;">Price: {guitar.price} €</span>
			</GuitarCard>
		{/each}
	</div>
{/if}

<style>
	h1 {
		font-family: 'Poppins', sans-serif;
		font-size: 36px;
		color: #333;
		margin-bottom: 20px;
		font-weight: 500;
	}

	h2 {
		font-size: 18px;
		color: #555;
	}

	.guitar-list {
		display: flex;
		flex-wrap: wrap;
		justify-content: space-between;
		margin-top: 20px;
	}

	.guitar-list > * {
		flex-basis: calc(33.333% - 10px);
		margin-bottom: 20px;
	}
</style>
