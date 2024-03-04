<script lang="ts">
	export let name = 'Marco Tidu';
	export let age = 39;
	export let description = 'Fullstack Developer';
	export let linkedin = 'https://www.linkedin.com/in/marco-tidu/';
</script>

<div class="about-me border border-gray-300 rounded p-6 my-4">
	<h1 class="text-4xl font-bold mb-4">About me</h1>

	<p class="mb-2"><span class="font-semibold">Name:</span> {name}</p>
	<p class="mb-2"><span class="font-semibold">Age:</span> {age}</p>
	<p class="mb-2"><span class="font-semibold">Description:</span> {description}</p>
	<p class="mb-2">
		<span class="font-semibold">LinkedIn:</span>
		<a href={linkedin} target="_blank" class="text-blue-600 hover:underline">{linkedin}</a>
	</p>
</div>
