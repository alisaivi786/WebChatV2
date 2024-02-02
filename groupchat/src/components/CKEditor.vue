<template>
    <textarea id="editor"></textarea>
</template>

<script>
import { defineComponent } from 'vue';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic' 

export default defineComponent({
    data() {
        return {
            editor: null,
        };
    },    
    mounted() {
        ClassicEditor.create(document.querySelector('#editor'))
            .then((editor) => {
                this.editor = editor;
            })
            .catch((error) => {
                console.error('Error creating editor:', error);
            });
    },
});
</script>
