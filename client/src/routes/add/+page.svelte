<script>
	let name = '';
	let description = '';
	let price = '';

	async function handleSubmit() {
		const formData = {
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
			console.log('Guitar added successfully!');
		} else {
			console.error('Failed to add guitar');
		}
	}
</script>

<form on:submit|preventDefault={handleSubmit}>
	<label for="name">Name:</label>
	<input type="text" id="name" bind:value={name} />

	<label for="description">Description:</label>
	<textarea id="description" rows="4" bind:value={description}></textarea>

	<label for="price">Price:</label>
	<input type="number" id="price" bind:value={price} />

	<button type="submit">Add Guitar</button>
</form>
