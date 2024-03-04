<script lang="ts">
	import { createEventDispatcher } from 'svelte';

	export let guitarId: number | undefined;
	const dispatch = createEventDispatcher();

	async function deleteGuitar() {
		dispatch('guitarDeleted', { guitarId });
	}
</script>

<article
	class="guitar-card flex flex-col justify-between h-64 w-64 border border-gray-300 rounded-md shadow-md p-4 mb-4"
>
	<h2 class="text-xl font-medium pb-2 border-b border-orange-500">
		<slot name="name" />
	</h2>

	<div class="description">
		<h4 class="font-semibold">Description</h4>
		<slot name="description" />
	</div>

	<div class="price">
		<slot name="price" />
	</div>

	<div>
		<button
			class="bg-red-500 hover:bg-red-600 text-white font-semibold py-2 px-4 rounded"
			on:click={deleteGuitar}
		>
			Delete
		</button>
	</div>
</article>
