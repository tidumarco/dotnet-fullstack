<script lang="ts">
	import type { Guitar } from '../../types/Guitar';

	let name: string;
	let description: string;
	let price: number | undefined;
	let confirmationMessage = '';
	let lastEnteredGuitar: Guitar;

	async function handleSubmit() {
		const formData: Guitar = {
			name,
			description,
			price
		};

		const response = await fetch('http://localhost:5024/guitar', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(formData)
		});

		if (response.ok) {
			confirmationMessage = 'Guitar added successfully!';
			window.alert(confirmationMessage);
			lastEnteredGuitar = formData;
			name = '';
			description = '';
			price = undefined;
		} else {
			confirmationMessage = 'Failed to add guitar';
			window.alert(confirmationMessage);
		}
	}
</script>

<form class="guitar-form" on:submit|preventDefault={handleSubmit}>
	<label for="name">Name:</label>
	<input type="text" id="name" bind:value={name} />

	<label for="description">Description:</label>
	<textarea id="description" rows="4" bind:value={description}></textarea>

	<label for="price">Price:</label>
	<input type="number" id="price" bind:value={price} />

	<button type="submit">Add Guitar</button>

	{#if confirmationMessage}
		<p>Last guitar added: {lastEnteredGuitar.name}</p>
	{/if}
</form>

<style>
	.guitar-form {
		max-width: 400px;
		margin-top: 40px;
		margin: 40px auto;
	}

	label {
		display: block;
		margin-bottom: 5px;
	}

	input[type='text'],
	input[type='number'],
	textarea {
		width: 100%;
		padding: 8px;
		margin-bottom: 10px;
		border: 1px solid #ccc;
		border-radius: 4px;
		box-sizing: border-box;
	}

	button {
		background-color: #007bff;
		color: #fff;
		border: none;
		border-radius: 4px;
		padding: 10px 20px;
		cursor: pointer;
	}

	button:hover {
		background-color: #0056b3;
	}
</style>
