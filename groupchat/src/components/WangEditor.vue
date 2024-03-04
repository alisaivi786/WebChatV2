<template>
  <div style="border: 1px solid #ccc">
    <Toolbar
      style="border-bottom: 1px solid #ccc"
      :editor="editorRef"
      :defaultConfig="toolbarConfig"
      :mode="mode"
    />
    <Editor
      style="height: 10vh; overflow-y: auto"
      v-model="valueHtml"
      @input="handleValueChange"
      :defaultConfig="editorConfig"
      :mode="mode"
      @onCreated="handleCreated"
      @keydown="handleKeyDown"
    />
  </div>
</template>

<script>
import "@wangeditor/editor/dist/css/style.css";

import { onBeforeUnmount, ref, shallowRef, onMounted } from "vue";
import { useStore } from "vuex";
import { Editor, Toolbar } from "@wangeditor/editor-for-vue";

export default {
  components: { Editor, Toolbar },
  props: ['sendMessage'],
  setup(props) {
    const editorRef = shallowRef();
    const valueHtml = ref("");
    const store = useStore();

    const handleValueChange = () => {
    };

    const handleKeyDown = (event) => {
      if (event.key === 'Enter') {
        //props.sendMessage();
        //event.preventDefault();
      }
    };

    onMounted(() => {
      setTimeout(() => {
      }, 1500);
    });

    var IMAGE_SVG =
      '<svg viewBox="0 0 1024 1024"><path d="M959.877 128l0.123 0.123v767.775l-0.123 0.122H64.102l-0.122-0.122V128.123l0.122-0.123h895.775zM960 64H64C28.795 64 0 92.795 0 128v768c0 35.205 28.795 64 64 64h896c35.205 0 64-28.795 64-64V128c0-35.205-28.795-64-64-64zM832 288.01c0 53.023-42.988 96.01-96.01 96.01s-96.01-42.987-96.01-96.01S682.967 192 735.99 192 832 234.988 832 288.01zM896 832H128V704l224.01-384 256 320h64l224.01-192z"></path></svg>';

    let toolbarConfig = {};
    toolbarConfig.toolbarKeys = [
      "headerSelect",
      "blockquote",
      "|",
      "bold",
      "underline",
      "italic",
      "through",
      "color",
      "bgColor",
      "|",
      "fontFamily",
      "|",
      "bulletedList",
      "numberedList",
      "|",
      "emotion",
      "insertLink",
      {
        key: "group-image",
        title: "editor.image",
        iconSvg: IMAGE_SVG,
        menuKeys: ["insertImage", "uploadImage"], 
      },
    ];
    const editorConfig = { placeholder: "Type here...", MENU_CONF: {} };

    editorConfig.MENU_CONF["uploadImage"] = {
      server: `${import.meta.env.VITE_UPLOAD_IMAGE_API_BASE_URL}/api/${import.meta.env.VITE_API_VERSION}/Message/UploadImage`,
      fieldName: "file",
      headers: {
        Accept: 'text/x-json',
        Authorization: `Bearer ${store.state.accessToken}`
      },
      onSuccess(file, res) {
        console.log(`${file.name} uploaded`, res);
      },
      onFailed(file, res) {
        console.log(`${file.name} failed`, res);
      },
      onError(file, err, res) {
        console.log(`${file.name} error`, err, res);
      },
    };

    onBeforeUnmount(() => {
      const editor = editorRef.value;
      if (editor == null) return;
      editor.destroy();
    });

    const handleCreated = (editor) => {
      editorRef.value = editor;      
    };

    return {
      editorRef,
      mode: "default",
      valueHtml,
      handleValueChange,
      handleKeyDown,
      toolbarConfig,
      editorConfig,
      handleCreated,
    };
  },
};
</script>
