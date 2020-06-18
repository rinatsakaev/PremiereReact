import VK, {Like} from 'react-vk';
import React from 'react';
export default function LikeButton({pageId}) {
    const handleLike = () => {
        const slug = window.location.pathname.split('/')[1];
        return fetch(`/api/likes/create?pageSlug=${slug}`)
            .then(() => alert("Лайк поставлен"))
            .catch(e => alert("Ошибка", e));
    };

    return <VK apiId={123456}>
        <Like pageId={pageId} onLike={() => handleLike()}/>
    </VK>
}
