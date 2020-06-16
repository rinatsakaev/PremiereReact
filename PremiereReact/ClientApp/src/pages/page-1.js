import React from 'react';
import VK, {Like} from 'react-vk';
import handleLike from '../helpers/handleLike';
export default function Page1(){
    return (<div>
        <h1>This is page 1</h1>
        <VK apiId={7512715}>
            <Like pageId={1} onLike={() => handleLike()}/>
        </VK>
    </div>)
}
