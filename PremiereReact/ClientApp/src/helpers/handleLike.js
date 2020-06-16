export default function handleLike(){
    const slug = window.location.pathname.split('/')[1];
    return fetch(`/api/likes/create?pageSlug=${slug}`)
        .then(() => console.log("Лайк поставлен"))
        .catch(x => console.log(x));
}
