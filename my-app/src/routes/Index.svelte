<script lang="ts">
	import { onMount } from 'svelte';
	import type { Drink } from '../types/Drink';

	let loading = true;
	let startup = false;
	let data;
	let ingredients: string[] = [];

	let drink: Drink;
	onMount(() => (startup = true));
	async function fetchData() {
		loading = true;
		try {
			const response = await fetch('https://www.thecocktaildb.com/api/json/v1/1/random.php');
			data = await response.json();
			drink = data.drinks[0];
			loading = false;
			startup = false;
		} catch (error) {
			console.error('Fetch Error:', error);
		}
	}

	const handleOnClik = async () => fetchData();
</script>

<div class="wrapper">
	<button on:click={handleOnClik}>Get new drink</button>
	{#if startup}<h2>Click to fetch a drink!</h2>{/if}
	{#if loading && !startup}<h2>Loading drinks...</h2>{/if}
	{#if !loading && data}
		<h2>{drink.strDrink}</h2>
		<img class="drink-thumb" src={drink.strDrinkThumb} alt="drink-thumb" />
		<p>Ingredients</p>
		<ul>
			{#each Object.entries(drink) as [key, value]}
				{#if key.startsWith('strIngredient') && value !== null}
					<li>
						{value}
					</li>
				{/if}
			{/each}
		</ul>

		<p>Measures</p>
		<ul>
			{#each Object.entries(drink) as [key, value]}
				{#if key.startsWith('strMeasure') && value !== null}
					<li>
						{value}
					</li>
				{/if}
			{/each}
		</ul>
		<p>Instructions</p>
		<div class="text-body">{drink.strInstructions}</div>
	{/if}
</div>

<style>
	.wrapper {
		display: flex;
		flex-direction: column;
		align-items: center;
		font-family: 'Courier New', Courier, monospace;
	}

	.drink-thumb {
		width: 300px;
		border-radius: 1rem;
	}

	.text-body {
		width: 300px;
		text-align: center;
	}

	p {
		max-width: 500px;
		text-align: center;
		font-weight: bold;
	}
</style>
