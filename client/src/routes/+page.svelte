<script lang="ts">
	import { onMount } from 'svelte';
	import GuitarCard from '../slots/Guitar.svelte';
	import type { Guitar } from '../types/Guitar';
	let data: Guitar[];
	let loadingState = true;
	let confirmationMessage = '';

	onMount(async () => {
		try {
			const response = await fetch('http://localhost:5024/Guitar');
			data = await response.json();
			loadingState = false;
		} catch (error) {}
	});

	async function handleDelete(event: any) {
		const deletedGuitarId = event.detail.guitarId;

		try {
			const response = await fetch(`http://localhost:5024/guitar/${deletedGuitarId}`, {
				method: 'DELETE'
			});
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

<h2>
	{#if loadingState == true}
		Loading...{/if}
</h2>
<h2>Guitars</h2>
{#if loadingState == false}
	<div class="guitar-cards">
		{#each data as guitar}
			<GuitarCard guitarId={guitar.id} on:guitarDeleted={handleDelete}>
				<span slot="name">{guitar.name}</span>
				<span slot="description">
					{guitar.description}
				</span>
				<span slot="price"><b><em>Price:</em></b> {guitar.price} €</span>
			</GuitarCard>
		{/each}
	</div>
{/if}

<style>
	.guitar-cards {
		display: flex;
		flex-wrap: wrap;
		justify-content: space-between; /* Adjust alignment as needed */
	}
</style>
