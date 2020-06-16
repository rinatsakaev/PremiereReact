import React from 'react';
import VK, {Like} from 'react-vk';
import handleLike from '../helpers/handleLike';
export default function Page2(){
    return (<div>
        <h1>This is page 2</h1>
        <VK apiId={7512715}>
            <Like pageId={2} onLike={() => handleLike()}/>
        </VK>
    </div>)
}
