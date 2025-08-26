function removeArtist() {
    // remover o artista com o id 3
const id = 3;

fetch(`http://localhost:5056/api/Artista/${id}`, {
  method: 'DELETE'
})
.then(response => {
  if (!response.ok) {
    throw new Error('Erro ao deletar o artista.');
  }
  console.log('Artista deletado com sucesso!');
})
.catch(error => {
  console.error('Houve um erro:', error);
});
}