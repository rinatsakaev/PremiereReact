export default function handleLike(){
    const slug = window.location.pathname.split('/')[1];
    return fetch(`/api/likes/create?pageSlug=${slug}`)
        .then(() => alert("Лайк поставлен"))
        .catch(e => alert("Ошибка", e));
}
